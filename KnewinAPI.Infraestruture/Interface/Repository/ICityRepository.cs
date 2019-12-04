using KnewinAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnewinAPI.Infraestruture.Interface.Repository
{
    public interface ICityRepository
    {
        List<City> GetAll();
        List<City> GetByName(string name);
        City GetById(Guid id);
        List<Border> GetByBorder(string name);
        int Create(City city);
        bool CityExists(string name);
        int SumPopulation(Guid[] ids);
        void Update(Guid id, City city);
    }
}
