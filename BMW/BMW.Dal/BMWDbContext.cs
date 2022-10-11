using BMW.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Dal
{
    public class BMWDbContext : DbContext
    {
        public BMWDbContext(DbContextOptions<BMWDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Cars> Cars { get; set; }
    }
}
