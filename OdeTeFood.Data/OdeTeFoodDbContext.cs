using Microsoft.EntityFrameworkCore;
using OdeTeFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeTeFood.Data
{
    public class OdeTeFoodDbContext : DbContext
    {
        public OdeTeFoodDbContext(DbContextOptions<OdeTeFoodDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
