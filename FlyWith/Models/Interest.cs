

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWith.Models
{
    public class Interest
    {
        public int InterestID { get; set; }

        [Display(Name = "Interest")]
        public string Name { get; set; }

        //foregien keys
        //each interest in witch group 
        [Display(Name = "Group of the interest")]
        public int InterestGroupID { get; set; }
        public virtual InterestGroup InterestGroup { get; set; }

        //Interests for each person one interst from the group
        public virtual ICollection<PersonalDetails_Interest_Level> PersonalDetails_Interest_Levels { get; set; }
    }
}
