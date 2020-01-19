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
        private readonly string myGazetaUrl = "http://mygazeta.com/гороскоп/";

        public GetHoroscopeCommand(string sign)
        {
            CommandName = "/" + sign;
            _sign = sign;
        }

        public override async Task ExecuteAsync(Message message, IBotService botService)
        {
            var today = DateTime.Today.ToString("dd-MM-yyyy");
            var url = myGazetaUrl + _sign + "/гороскоп-" 
                + _sign + "-" + today + ".html";

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response == null || response.StatusCode != HttpStatusCode.OK) return;

            var source = await response.Content.ReadAsStringAsync();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = Parser.Parse(document);
            string toSend = $"[{_sign}] - {today} \n";
            var i = 0;
            foreach (var elem in result)
            {
                i++;
                if ((i % 2 == 0) && (i != 22) && (i < 25))
                    toSend += elem + "\n";
            }

            await botService.Client.SendTextMessageAsync(message.Chat.Id, toSend);
        }

        public override bool Contains(string command)
        {
            return (command.ToLower() == CommandName);
        }
    }
}