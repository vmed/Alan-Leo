using System.Threading.Tasks;
using Telegram.Bot;

namespace HoroscopeBot.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }

        Task InitAsync { get; }
    }
}