using Bomholt.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Infrastructure.DB.Data
{
    public class PetShopContext: DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt): base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Pets)
                .WithOne(p => p.Owner)
                .OnDelete(DeleteBehavior.SetNull)
                ;

            //modelBuilder.Entity<Owner>()
            //    .HasKey(o => o.ID)
            //    ;

            
            //modelBuilder.Entity<Pet>()
            //    .HasOne(p => p.Owner)
            //    .WithMany(o => o.Pets)
            //    ;
        }
    }
}
