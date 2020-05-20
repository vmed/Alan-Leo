using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HoroscopeBot.App.Services
{
    public interface IMessageService
    {
        Task GetMessage(Update update);
    }
}