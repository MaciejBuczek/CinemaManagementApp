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
        public string CommentContent { get; set; }
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        [ForeignKey("Movie")]
        public int IdMovie { get; set; }
    }
}
