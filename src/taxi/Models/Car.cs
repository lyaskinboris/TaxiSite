using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxi.Models
{
    public class Car
    {
        public Int32 Id { get; set; }
        [Required]
        public string ColourCar { get; set; }
        [Required]
        public string NumberCar { get; set; }
        [Required]
        public string ModelCar { get; set; }
        [Required]
        public Int32 CompanyTaxiId { get; set; }
    }
}
