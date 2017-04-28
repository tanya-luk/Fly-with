using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class Sex
    {
        public int SexID { get; set; }

        [Display(Name = "Sex")]
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
    }
}
