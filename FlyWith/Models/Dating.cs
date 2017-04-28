

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWith.Models
{
    public class Dating
    {
        //variables of the dating table
        [Display(Name = "From age")]
        public int FromAge { get; set; }

        [Display(Name = "To Age")]
        public int ToAge { get; set; }

        //the private and foreigien keys
        [Display(Name = "Sex")]
        public int SexID { get; set; }
        public virtual Sex Sex { get; set; }
        [Key, ForeignKey("PersonalDetails")]
        public int PersonalDetailsID { get; set; }
        public virtual PersonalDetails PersonalDetails { get; set; }
    }
}
