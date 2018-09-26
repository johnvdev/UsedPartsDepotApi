namespace UsedPartsDepotAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RetrievePartsDepotDB : DbContext
    {
        public RetrievePartsDepotDB()
            : base("name=RetrievePartsDepotDB")
        {
        }

        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<depotUser> depotUsers { get; set; }
        public virtual DbSet<partsForSale> partsForSales { get; set; }
        public virtual DbSet<partsSold> partsSolds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>()
                .Property(e => e.cMake)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .Property(e => e.cModel)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .Property(e => e.cVin)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .HasMany(e => e.partsForSales)
                .WithOptional(e => e.car)
                .HasForeignKey(e => e.carID);

            modelBuilder.Entity<car>()
                .HasMany(e => e.partsSolds)
                .WithOptional(e => e.car)
                .HasForeignKey(e => e.carID);

            modelBuilder.Entity<car>()
                .HasMany(e => e.depotUsers)
                .WithMany(e => e.cars)
                .Map(m => m.ToTable("usersCars").MapLeftKey("car_id").MapRightKey("user_id"));

            modelBuilder.Entity<depotUser>()
                .Property(e => e.fName)
                .IsUnicode(false);

            modelBuilder.Entity<depotUser>()
                .Property(e => e.lName)
                .IsUnicode(false);

            modelBuilder.Entity<partsForSale>()
                .Property(e => e.pTitle)
                .IsUnicode(false);

            modelBuilder.Entity<partsForSale>()
                .Property(e => e.pDescription)
                .IsUnicode(false);

            modelBuilder.Entity<partsSold>()
                .Property(e => e.pSTitle)
                .IsUnicode(false);

            modelBuilder.Entity<partsSold>()
                .Property(e => e.pSDescription)
                .IsUnicode(false);
        }
    }
}
