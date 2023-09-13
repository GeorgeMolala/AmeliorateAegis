using AmeliorateAegis.Models;
using AmeliorateAegis.Models.Parents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Teacher.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centre>().HasData(
               new Centre { Id = 1, Name = "Kabega", AddressLine1 = "123 John Newton SW", AddressLine2 = "Newton Park" },
               new Centre { Id = 2, Name = "Sol Futi", AddressLine1 = "237 John Newton SW", AddressLine2 = "New Brighton" },
               new Centre { Id = 3, Name = "Daku", AddressLine1 = "123 John Newton SW", AddressLine2 = "Newton Park" }
               );

            modelBuilder.Entity<Period>().HasData(
              new Period { Id = 1, Name = "Term 1" },
              new Period { Id = 2, Name = "Term 2" },
              new Period { Id = 3, Name = "Term 3" },
              new Period { Id = 4, Name = "Term 4" }
              );

            modelBuilder.Entity<Programme>().HasData(
            new Programme { Id = 1, Name = "Literacy Development", CentreId = 1 },
            new Programme { Id = 2, Name = "Math And Science", CentreId = 2 },
            new Programme { Id = 3, Name = "Song And Music", CentreId = 1 },
            new Programme { Id = 4, Name = "Art And Music", CentreId = 1 },
            new Programme { Id = 5, Name = "Language And Speech", CentreId = 3 }
            );

        }
    }
}
