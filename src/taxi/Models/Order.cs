using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxi.Models
{
    public class Order
    {
        public Int32 Id { get; set; }
        [Required]
        public string AddressFrom { get; set; }
        [Required]
        public string AddressWhere { get; set; }
        [Required]
        public string DataTime { get; set; }
        public string OtherInfo { get; set; }
        public Int32 CarId { get; set; }
        [Required]
        public String ApplicationUserId { get; set; }
    }
}
