using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SNGPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ConnectionType> ConnectionTypes { get; set; }
        public DbSet<ConnectionForm> ConnectionForms { get; set; }
    }
}