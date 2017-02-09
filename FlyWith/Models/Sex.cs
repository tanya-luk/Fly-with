using System.Collections.Generic;

namespace FlyWith.Models
{
    public class Sex
    {
        public int SexID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
    }
}
