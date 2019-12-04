using Microsoft.EntityFrameworkCore;
using System;

namespace KnewinAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var City_Fl = new City { Id = new Guid("6cdc43e3-b5ea-4953-ac82-791785963f78"), Name = "Florianópolis", Population = 500000 };
            var City_Sj = new City { Id = new Guid("ada29b33-5897-4fa1-8d67-f2852435720b"), Name = "Palhoça", Population = 165000 };
            var City_Ph = new City { Id = new Guid("78f2c0ed-4530-4d3c-86c1-5582e98c4d1f"), Name = "São José", Population = 240000 };

            var City_Sa = new City { Id = Guid.NewGuid(), Name = "Santo Amaro da Imperatriz", Population = 1000 };
            var City_Bi = new City { Id = Guid.NewGuid(), Name = "Biguaçu", Population = 1000 };
            var City_Go = new City { Id = Guid.NewGuid(), Name = "Governador Celso Ramos", Population = 1000 };
            var City_An = new City { Id = Guid.NewGuid(), Name = "Antônio Carlos", Population = 1000 };
            var City_Ag = new City { Id = Guid.NewGuid(), Name = "Águas Mornas", Population = 1000 };
            var City_Sp = new City { Id = Guid.NewGuid(), Name = "São Pedro de Alcântara", Population = 1000 };

            modelBuilder.Entity<City>().HasData(City_Fl);
            modelBuilder.Entity<City>().HasData(City_Sj);
            modelBuilder.Entity<City>().HasData(City_Ph);
            modelBuilder.Entity<City>().HasData(City_Sa);
            modelBuilder.Entity<City>().HasData(City_Bi);
            modelBuilder.Entity<City>().HasData(City_Go);
            modelBuilder.Entity<City>().HasData(City_An);
            modelBuilder.Entity<City>().HasData(City_Ag);
            modelBuilder.Entity<City>().HasData(City_Sp);


            var Border_Fl = new Border { Id = new Guid("838a0ab9-5dc9-4740-b384-dbde067fb213"), City = "São José", CityId = new Guid("6cdc43e3-b5ea-4953-ac82-791785963f78") };
            var Border1_Sj = new Border { Id = new Guid("62fb9366-18d2-4bef-abd2-2fea3e864810"), City = "Palhoça", CityId = new Guid("78f2c0ed-4530-4d3c-86c1-5582e98c4d1f") };
            var Border2_Sj = new Border { Id = new Guid("0d744bdf-8783-49e8-9b1a-d1ffe6f9ebc4"), City = "Florianópolis", CityId = new Guid("78f2c0ed-4530-4d3c-86c1-5582e98c4d1f") };
            var Border_Ph = new Border { Id = new Guid("506aa532-3bf6-413b-9fbf-ca4ff8290206"), City = "São José", CityId = new Guid("ada29b33-5897-4fa1-8d67-f2852435720b") };

            modelBuilder.Entity<Border>().HasData(Border_Fl);
            modelBuilder.Entity<Border>().HasData(Border1_Sj);
            modelBuilder.Entity<Border>().HasData(Border2_Sj);
            modelBuilder.Entity<Border>().HasData(Border_Ph);
        }
    }
}
