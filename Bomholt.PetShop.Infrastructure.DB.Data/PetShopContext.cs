// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PetShopContext.cs" company="Sven">
//   
// </copyright>
// <summary>
//   Defines the PetShopContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bomholt.PetShop.Infrastructure.DB.Data
{
    using Bomholt.PetShop.Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

        //public DbSet<PetColor> PetColors { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Pets)
                .WithOne(p => p.Owner).OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<PetColor>().HasKey(pc => new { pc.PetId, pc.ColorId });

            //modelBuilder.Entity<PetColor>()
            //    .HasOne<Pet>(pc => pc.Pet)
            //    .WithMany(p => p.PetColors).HasForeignKey(pc => pc.PetId);

            //modelBuilder.Entity<PetColor>()
            //    .HasOne<Color>(pc => pc.Color)
            //    .WithMany(c => c.PetColor).HasForeignKey(pc => pc.ColorId);

            /*
            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.SId);


            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CId);
            */

            // modelBuilder.Entity<Pet>()
            // .HasOne(p => p.Owner)
            // .WithMany(o => o.Pets)
            // .OnDelete(DeleteBehavior.SetNull)
            // ;
        }
    }
}
