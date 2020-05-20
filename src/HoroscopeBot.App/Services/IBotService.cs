using System.Threading.Tasks;
using Telegram.Bot;

namespace HoroscopeBot.App.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }

        Task InitAsync { get; }
    }
}