using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Comment")]
        public string CommentContent { get; set; }
        
        /*public int? IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer Customer { get; set; }*/
        
        public int? IdMovie { get; set; }
        [ForeignKey("IdMovie")]
        public virtual Movie Movie { get; set; }

    }
}
