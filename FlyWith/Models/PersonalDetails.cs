using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWith.Models
{
    public class PersonalDetails
    {
        public int PersonalDetailsID { get; set;}
        [StringLength(128), MinLength(3)]
        [ForeignKey("AspNetUser")]
        public virtual string AspNetUserId { get; set; }


        public ApplicationUser AspNetUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        //Meal Type
        public int MealTypeID { get; set; }
        public virtual MealType MealType { get; set; }

        //Country
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        //Sex
        public int SexID { get; set; }
        public virtual Sex Sex { get; set; }

        //languages
        public virtual ICollection<PersonalDetails_Language_LanguageLevel> PersonalDetails_Language_LanguageLevels { get; set; }

        //Interests
        public virtual ICollection<PersonalDetails_Interest_Level> PersonalDetails_Interest_Levels { get; set; }

        //Do in Flight
        public virtual ICollection<PesonalDetail_DoInFlight_YesNoAnswer> PesonalDetail_DoInFlight_YesNoAnswers { get; set; }
    }
}
