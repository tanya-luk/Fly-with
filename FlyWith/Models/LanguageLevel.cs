using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class LanguageLevel
    {
        public int LanguageLevelID { get; set; }

        [Display(Name = "The level of the language")]
        public string Name { get; set; }
    }
}
