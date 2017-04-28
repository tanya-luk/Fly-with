using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWith.Models
{
    public class Level
    {
        public int LevelID { get; set; }

        [Display(Name = "Level")]
        public string Name { get; set; }
    }
}
