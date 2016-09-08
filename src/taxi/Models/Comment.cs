using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxi.Models
{
    public class Comment
    {
        public Int32 Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Rating { get; set; }
        [Required]
        public Int32 CompanyTaxiId { get; set; }
        [Required]
        public String ApplicationUserId { get; set; }
    }
}
