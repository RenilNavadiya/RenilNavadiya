using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RKGems.Models;

namespace RKGems.Data
{
    public class RKGemsContext : DbContext
    {
        public RKGemsContext (DbContextOptions<RKGemsContext> options)
            : base(options)
        {
        }

        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<FourP> FourPs { get; set; }
        public DbSet<Russian> Russians { get; set; }
        public DbSet<Polish> Polishes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().HasData(
                new Result { ResultId = 1, ResultThan = 50, ResultWeight = 75, PurchaseId = 1},
                new Result { ResultId = 2, ResultThan = 60, ResultWeight = 65, PurchaseId = 2},
                new Result { ResultId = 3, ResultThan = 70, ResultWeight = 55, PurchaseId = 3}
                );
            modelBuilder.Entity<FourP>().HasData(
                new FourP { FourPId = 1, FourPQuantity = 50, FourPWeight = 70, PurchaseId = 1, IdOfResult = 1},
                new FourP { FourPId = 2, FourPQuantity = 60, FourPWeight = 60, PurchaseId = 2, IdOfResult = 2 },
                new FourP { FourPId = 3, FourPQuantity = 70, FourPWeight = 50, PurchaseId = 3, IdOfResult = 3 }
                );
            modelBuilder.Entity<Russian>().HasData(
                new Russian {RussianId = 1, RussianQuantity = 50, RussianWeight = 65, PurchaseId = 1, IdOfFourP = 1 },
                new Russian {RussianId = 2, RussianQuantity = 60, RussianWeight = 55, PurchaseId = 2, IdOfFourP = 2 },
                new Russian {RussianId = 3, RussianQuantity = 70, RussianWeight = 45, PurchaseId = 3, IdOfFourP = 3 }
                );
            modelBuilder.Entity<Polish>().HasData(
               new Polish { PolishId = 1, PolishQuantity = 50, PolishWeight = 60, PurchaseId = 1, IdOfResult = 1 },
               new Polish { PolishId = 2, PolishQuantity = 60, PolishWeight = 50, PurchaseId = 2, IdOfResult = 2 },
               new Polish { PolishId = 3, PolishQuantity = 70, PolishWeight = 40, PurchaseId = 3, IdOfResult = 3 }
               );

            modelBuilder.Entity<Purchase>().HasData(
               new Purchase { Id = 1, ItemNumber = "A1", Price = 1000, PurchaseWeight = 100, DueDate = new DateTime(2022, 1, 1), PartyName = "Renil"},
               new Purchase { Id = 2, ItemNumber = "A2", Price = 2000, PurchaseWeight = 150, DueDate = new DateTime(2022, 2, 1), PartyName = "Keyur" },
               new Purchase { Id = 3, ItemNumber = "A3", Price = 3000, PurchaseWeight = 200, DueDate = new DateTime(2022, 3, 1), PartyName = "Piyush" }
               );
        }
    }
}
