using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using HoroscopeBot.Services;
using Telegram.Bot.Types;

namespace HoroscopeBot.Models.Commands
{
    public class GetHoroscopeCommand : Command
    {
        public override string CommandName { get; set; }
        private readonly string _sign;

        public GetHoroscopeCommand(string sign)
        {
            CommandName = "/" + sign;
            _sign = sign;
        }

        public override async Task ExecuteAsync(Message message, IBotService botService)
        {
            var url = "http://mygazeta.com/гороскоп/" + _sign + "/гороскоп-" + _sign + "-"
                      + DateTime.Today.ToString("dd-MM-yyyy") + ".html";

            Console.WriteLine(url);
            var response = await new HttpClient().GetAsync(url);
            string source = null;
            var all = "";
            var parser = new Parser();
            var i = 0;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = Parser.Parse(document);
            foreach (var elem in result)
            {
                i++;
                if ((i % 2 == 0) && (i != 22) && (i < 25))
                    all += elem;
            }

            await botService.Client.SendTextMessageAsync(message.Chat.Id, all);
        }

        public override bool Contains(string command)
        {
            return (command == CommandName);
        }
    }
}