using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HoroscopeBot.App.Services
{
    public class MessageService : IMessageService
    {
        private readonly IBotService _bot;
        private readonly ILogger<MessageService> _logger;

        public MessageService(IBotService bot, ILogger<MessageService> logger)
        {
            _bot = bot;
            _logger = logger;
        }
        public async Task GetMessage(Update update)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }
            var message = update.Message;
            _logger.LogInformation("Received Message from {0}: {1}", message.Chat.Id, message.Text);

            var commands = BotService.Commands;
            foreach (var command in commands)
            {
                if (!command.Contains(message.Text)) continue;
                await command.ExecuteAsync(message, _bot);
                break;
            }
        }
    }
}