using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(200)]
        public string FullName { get; set; }
    }
}