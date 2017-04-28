using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class InterestGroup
    {
        public int InterestGroupID { get; set; }

        [Display(Name = "The group of the Interest")]
        public string Name { get; set; }

        public virtual ICollection<Interest> Interest { get; set; }
    }
}
