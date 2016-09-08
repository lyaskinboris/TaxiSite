using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxi.Models
{
    public class CompanyTaxiViewModel
    {
        public CompanyTaxi Item { get; set; }
        [Required]
        public string AddressOffice { get; set; }
        [Required]
        public int PhoneCompany { get; set; }
        [Required]
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
    }
}
