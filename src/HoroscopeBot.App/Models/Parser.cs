using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace HoroscopeBot.App.Models
{
    public class Parser
    {
        public static IEnumerable<string> Parse(IHtmlDocument document)
        {
            var items = document.QuerySelectorAll("p");
            return items.Select(item => item.TextContent).ToArray();
        }
    }
}