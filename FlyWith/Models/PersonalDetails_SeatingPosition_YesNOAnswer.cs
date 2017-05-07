
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlyWith.Models
{
    public class PersonalDetails_SeatingPosition_YesNOAnswer
    {
        
    //
            [Key, Column(Order = 0)]
            public int PersonalDetailsID { get; set; }
            [ForeignKey("PersonalDetailsID")]
            public virtual PersonalDetails PersonalDetails { get; set; }

            [Display(Name = "Last Name")]
            [Key, Column(Order = 1)]
            public int SeatingPositionID { get; set; }
            [ForeignKey("SeatingPositionID")]
            public virtual SeatingPosition SeatingPosition { get; set; }

            //Can be more then one time for pair person and language

            public int YesNoAnswerID { get; set; }
            [ForeignKey("YesNoAnswerID")]
            public virtual YesNoAnswer YesNoAnswer { get; set; }
       
    }
}