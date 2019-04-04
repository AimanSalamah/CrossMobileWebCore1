﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace API.Models
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<BLL.Tasks> Tasks { get; set; }

        public DbSet<BLL.PhoneBooks> PhoneBook { get; set; }
    }
}
