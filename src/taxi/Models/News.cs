using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxi.Models
{
    public class News
    {
        public Int32 Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DescriptionNews { get; set; }
        public string PictureUrl { get; set; }
    }
}
