using System.Collections.Generic;

namespace FlyWith.Models
{
    public class YesNoAnswer
    {
        public int YesNoAnswerID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
    }
}
