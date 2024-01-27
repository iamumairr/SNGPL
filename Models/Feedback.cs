using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public string Rating { get; set; }
        public string Environment { get; set; }

        [Required(ErrorMessage = "Please write down description")]
        public string Description { get; set; }
    }
}