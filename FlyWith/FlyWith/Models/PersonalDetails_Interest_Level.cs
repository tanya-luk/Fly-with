using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlyWith.Models
{
    public class PersonalDetails_Interest_Level
    {
        [Key Column(Order = 0)]
        public int PersonalDetailsID { get; set; }
        [ForeignKey("PersonalDetailsID")]
        public virtual PersonalDetails PersonalDetails { get; set; }

        [Key Column(Order =1)]
        public int InterestID { get; set; }
        [ForeignKey("InterestID")]
        public virtual Interest Interest { get; set; }

        //Can be more then one time for pair person and language
        
        public int LevelID { get; set; }
        [ForeignKey("LevelID")]
        public virtual Level Level { get; set; }
    }
}