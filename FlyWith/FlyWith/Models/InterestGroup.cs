using System.Collections.Generic;

namespace FlyWith.Models
{
    public class InterestGroup
    {
        public int InterestGroupID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Interest> Interest { get; set; }
    }
}
