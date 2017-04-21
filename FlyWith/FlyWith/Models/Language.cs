using System.Collections.Generic;

namespace FlyWith.Models
{
    public class Language
    {
        public int LanguageID { get; set; }
        public string Name { get; set; }

        //levels of language for each person
        public virtual ICollection<PersonalDetails_Language_LanguageLevel> PersonalDetails_Language_LanguageLevels { get; set; }
    }
}
