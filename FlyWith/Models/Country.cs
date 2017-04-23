using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class Country
    {
        
        public int CountryID { get; set; }
        [Display(Name = "Country name")]
        public string Name { get; set; }

        //foregein key
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
    }
}
