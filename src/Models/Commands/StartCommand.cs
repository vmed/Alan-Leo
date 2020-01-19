using System;
using System.Threading.Tasks;
using HoroscopeBot.Services;

namespace HoroscopeBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string CommandName { get => "/start"; set => throw new NotImplementedException(); }

        public override bool Contains(string command)
        {
            return (command == CommandName);
        }

        public override async Task ExecuteAsync(Telegram.Bot.Types.Message message, IBotService bot)
        {           
            await bot.Client.SendTextMessageAsync(message.Chat.Id, "тут тип гороскоп. чтобы получить гороскоп на сегодня. пиши аля  " + '\u0022' + "/овен" + '\u0022' + "," + '\u0022' + " /телец" + '\u0022' + "ну ты понел");
        }
    }
}