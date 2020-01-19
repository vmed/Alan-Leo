using System.Collections.Generic;

namespace HoroscopeBot.Models
{
    public static class AstroSignsRepository
    {
        public static IEnumerable<string> AstroSigns =>
            new List<string>() { "овен", "телец", "близнецы", "рак",
                "лев", "дева", "весы", "скорпион",
                "стрелец", "козерог", "водолей", "рыба"};
    }
}