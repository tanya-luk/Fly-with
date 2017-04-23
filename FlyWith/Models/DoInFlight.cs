using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    //the flight mood class
    public class DoInFlight
    {
        public int DoInFlightID { get; set; }
        [Display(Name = "Flight mood")]

        public string Name { get; set; }
        //Do in flight for each person one interst from the group
        public virtual ICollection<PesonalDetail_DoInFlight_YesNoAnswer> PesonalDetail_DoInFlight_YesNoAnswers { get; set; }
    }
}
