using System.Threading.Tasks;
using HoroscopeBot.App.Services;
using Telegram.Bot.Types;

namespace HoroscopeBot.App.Models.Commands
{
    public abstract class Command
    {
        public abstract string CommandName { get; set; }

        public abstract Task ExecuteAsync(Message message, IBotService botService);

        public abstract bool Contains(string command);
    }
}