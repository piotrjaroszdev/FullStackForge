using fullstackforge.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace fullstackforge.data
{
    public class FullStackForageDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FullStackForageDbContext(DbContextOptions<FullStackForageDbContext> options) : base(options) { }
    }

}
