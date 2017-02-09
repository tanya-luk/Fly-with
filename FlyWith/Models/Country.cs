using System.Collections.Generic;

namespace FlyWith.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
    }
}
