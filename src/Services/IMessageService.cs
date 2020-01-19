using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HoroscopeBot.Services
{
    public interface IMessageService
    {
        Task GetMessage(Update update);
    }
}