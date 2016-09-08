using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxi.Models
{
    public class CompanyTaxi
    {
        public Int32 Id { get; set; }
        [Required]
        public string AddressOffice { get; set; }
        [Required]
        public int PhoneCompany { get; set; }
        [Required]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
    }
}
