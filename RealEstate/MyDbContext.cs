using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using UserManagement.Models;

namespace RealEstate
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Listing> Listings { get; set; }

    }

}

