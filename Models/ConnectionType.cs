using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Models
{
    public class ConnectionType
    {
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        [Remote("IsAlreadyExists", "ConnectionType", AdditionalFields = "Id", ErrorMessage = "This name already exists")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<ConnectionForm> ConnectionForms { get; set; }
    }
}