using Microsoft.AspNetCore.Mvc.Rendering;
using SNGPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.ViewModels
{
    public class ConnectionFormVM
    {
        public ConnectionForm ConnectionForm { get; set; }
        public IEnumerable<SelectListItem> connetionTypes { get; set; }
    }
}