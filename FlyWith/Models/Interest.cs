

using System.Collections.Generic;

namespace FlyWith.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string Name { get; set; }

        //each interest in witch group 
        public int InterestGroupID { get; set; }
        public virtual InterestGroup InterestGroup { get; set; }

        //Interests for each person one interst from the group
        public virtual ICollection<PersonalDetails_Interest_Level> PersonalDetails_Interest_Levels { get; set; }
    }
}
