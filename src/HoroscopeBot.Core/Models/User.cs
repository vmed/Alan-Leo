using System.ComponentModel.DataAnnotations;
using HoroscopeBot.Core.Enums;

namespace HoroscopeBot.Core.Models
{
    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        
        //user telegram id
        public long TgId { get; set; }
        
        //user telegram name
        public string TgName { get; set; }
        
        public Language Language { get; set; }
    }
}