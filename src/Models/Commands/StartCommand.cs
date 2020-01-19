using System;
using System.Threading.Tasks;
using HoroscopeBot.Services;

namespace HoroscopeBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string CommandName { get => "/start"; set => throw new NotImplementedException(); }

        public override bool Contains(string command)
        {
            return (command == CommandName);
        }

        public override async Task ExecuteAsync(Telegram.Bot.Types.Message message, IBotService bot)
        {           
            await bot.Client.SendTextMessageAsync(message.Chat.Id, "Я бот призрака Алана Лео. Я даю гороскоп на сегодняшнюю дату. Напиши мне команду, чтобы узнать гороскоп на сегодня. Например: /овен");
        }
    }
}