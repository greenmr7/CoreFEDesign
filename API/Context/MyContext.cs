using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Merk> Merks { get; set; }
        public DbSet<Konsumen> Konsumens { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
    }
}
