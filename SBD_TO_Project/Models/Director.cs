using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    [Table("Director")]
    public class Director : Person
    {
        public string Alias { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
