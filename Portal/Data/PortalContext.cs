using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace Portal.Models
{
    public class PortalContext : DbContext
    {
        public PortalContext (DbContextOptions<PortalContext> options)
            : base(options)
        {
        }

        public DbSet<BLL.Tasks> Tasks { get; set; }

        public DbSet<BLL.PhoneBooks> PhoneBooks { get; set; }
    }
}
