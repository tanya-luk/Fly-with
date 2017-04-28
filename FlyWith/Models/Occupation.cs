using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyWith.Models
{
    public class Occupation
    {
        public int OccupationID   { get; set; }
        [Display(Name = "Occupation")]
        public String Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }

    }
}