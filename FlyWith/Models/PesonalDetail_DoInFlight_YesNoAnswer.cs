using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlyWith.Models
{
    public class PesonalDetail_DoInFlight_YesNoAnswer
    {
        [Key Column(Order = 0)]
        public int PersonalDetailsID { get; set; }
        [ForeignKey("PersonalDetailsID")]
        public virtual PersonalDetails PersonalDetails { get; set; }

        [Key Column(Order = 1)]
        public int DoInFlightID { get; set; }
        [ForeignKey("DoInFlightID")]
        public virtual DoInFlight DoInFlight { get; set; }

        //Can be more then one time for pair person and language

        public int YesNoAnswerID { get; set; }
        [ForeignKey("YesNoAnswerID")]
        public virtual YesNoAnswer YesNoAnswer { get; set; }
    }
}
