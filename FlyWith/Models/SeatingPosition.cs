using System.Collections.Generic;

namespace FlyWith.Models
{
    public class SeatingPosition
    {
        public int SeatingPositionID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails_SeatingPosition_YesNOAnswer> PersonalDetails_SeatingPosition_YesNoAnswer { get; set; }

    }
}
