using BMW.Domain.Entity;
using BMW.Domain.Enum;
using BMW.Domain.Helpers;
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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new User
                {
                    Id = 1,
                    Name = "ITHomester",
                    Password = HashPasswordHelper.HashPassowrd("123456"),
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                //builder.HasOne(x => x.Profile)
                //    .WithOne(x => x.User)
                //    .HasPrincipalKey<User>(x => x.Id)
                //    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}