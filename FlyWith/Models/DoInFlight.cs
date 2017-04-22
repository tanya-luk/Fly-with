using System.Collections.Generic;

namespace FlyWith.Models
{
    public class DoInFlight
    {
        public int DoInFlightID { get; set; }
        public string Name { get; set; }
        //Do in flight for each person one interst from the group
        public virtual ICollection<PesonalDetail_DoInFlight_YesNoAnswer> PesonalDetail_DoInFlight_YesNoAnswers { get; set; }
    }
}
