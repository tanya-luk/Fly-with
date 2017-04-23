using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class YesNoAnswer
    {
        public int YesNoAnswerID { get; set; }

        [Display(Name = "Yes or no answer name")]
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
    }
}
