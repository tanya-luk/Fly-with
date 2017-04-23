using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyWith.Models
{
    public class Occupation
    {
        public int OccupationId   { get; set; }

        [Display(Name = "Occupation name")]
        public String Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }

    }
}