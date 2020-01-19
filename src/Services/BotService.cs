using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HoroscopeBot.Models;
using HoroscopeBot.Models.Commands;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace HoroscopeBot.Services
{
    public class BotService : IBotService
    {
        private readonly BotConfig _config;
        
        private static List<Command> commandsList = new List<Command>();
        
        public static IEnumerable<Command> Commands => commandsList.AsReadOnly();
        
        public TelegramBotClient Client { get; }
        
        public Task InitAsync { get; private set; }

        public BotService(IOptions<BotConfig> config)
        {
            _config = config.Value;
            Client = new TelegramBotClient(_config.BotToken);

            commandsList.Add(new StartCommand());

            foreach (var sign in AstroSignsRepository.AstroSigns)
            {
                commandsList.Add(item: new GetHoroscopeCommand(sign));
            }

            InitAsync = Client.SetWebhookAsync(_config.Webhook);
        }
    }
}