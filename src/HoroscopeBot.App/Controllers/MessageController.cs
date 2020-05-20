using System;
using System.Threading.Tasks;
using HoroscopeBot.App.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace HoroscopeBot.App.Controllers
{
    [Route("api/update")]
    public class MessageController : Controller
    {
        private readonly IMessageService _message;
        public MessageController(IMessageService message)
        {
            _message = message;
        }
        //POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _message.GetMessage(update);
            return Ok();
        }
    }
}