

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWith.Models
{
    public class PersonalDetails_Language_LanguageLevel
    {
        [Key Column(Order = 0)]
        public int PersonalDetailsID { get; set; }
        [ForeignKey("PersonalDetailsID")]
        public virtual PersonalDetails PersonalDetails { get; set; }

        [Key Column(Order = 1)]
        public int LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; }

        //Can be more then one time for pair person and language
        
        public int LevelID { get; set; }
        [ForeignKey("LevelID")]
        public virtual LanguageLevel LanguageLevel { get; set; }
    }
}
