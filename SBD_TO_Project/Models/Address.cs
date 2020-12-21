using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
        [Required]
        public string Town { get; set; }
        public string Street { get; set; }
        [Display(Name = "Apartment number")]
        public string ApartmentNumber { get; set; }
    }
}
