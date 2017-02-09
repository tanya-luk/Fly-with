

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWith.Models
{
    public class Dating
    {
        public int DatingID { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public int SexID { get; set; }
        public virtual Sex Sex { get; set; }
        [Key, ForeignKey("PersonalDetails")]
        public int PersonalDetailsID { get; set; }
        public virtual PersonalDetails PersonalDetails { get; set; }
    }
}
