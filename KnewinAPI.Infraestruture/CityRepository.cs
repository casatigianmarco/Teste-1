using KnewinAPI.Commom.Extensions;
using KnewinAPI.Infraestruture.Interface.Repository;
using KnewinAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KnewinAPI.Infraestruture
{
    public class CityRepository : ICityRepository
    {
        public ApplicationDbContext DbContext { get; set; }

        public CityRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public List<City> GetAll()
        {
            return DbContext.City
                .Include(b => b.Border)
                .ToList();
        }

        public City GetById(Guid id)
        {
            return DbContext.City
                 .Include(b => b.Border)
                 .FirstOrDefault(c => c.Id == id);
        }

        public City GetByName(string name)
        {
            return DbContext.City
                 .Include(b => b.Border)
                 .Where(w => w.Name.Contains(name))
                 .FirstOrDefault();
        }

        public int Create(City city)
        {
            DbContext.City.Add(city);
            return DbContext.SaveChanges();
        }

        public bool CityExists(string name)
        {
            return DbContext.City.Where(w => w.Name.Contains(name)).Any();
        }

        public int SumPopulation(Guid[] ids)
        {
            return DbContext.City.Where(w => ids.Contains(w.Id)).Sum(s => s.Population);
        }

        public void Update(Guid id, City city)
        {
            DbContext.Entry(city).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public List<Border> GetByBorder(string name)
        {
            return DbContext.Border
                 .Where(w => w.City.Contains(name))
                 .ToList();
        }
    }
}
