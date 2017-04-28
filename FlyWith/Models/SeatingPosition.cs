using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class SeatingPosition
    {
        public int SeatingPositionID { get; set; }

        [Display(Name = "Seating position")]
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails_SeatingPosition_YesNOAnswer> PersonalDetails_SeatingPosition_YesNoAnswer { get; set; }

    }
}
