using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApproval.Models
{
   

        public class AppDbContext : DbContext
        {

            public AppDbContext(DbContextOptions<AppDbContext> options)
                 : base(options)
            {
            }

            public DbSet<userSignup> signup { get; set; }
            public DbSet<Admin> Admin { get; set; }

    }
    
}
