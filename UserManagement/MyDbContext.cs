using System;
using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

}

