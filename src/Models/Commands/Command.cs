using System.Threading.Tasks;
using HoroscopeBot.Services;
using Telegram.Bot.Types;

namespace HoroscopeBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string CommandName { get; set; }

        public abstract Task ExecuteAsync(Message message, IBotService botService);

        public abstract bool Contains(string command);
    }
}