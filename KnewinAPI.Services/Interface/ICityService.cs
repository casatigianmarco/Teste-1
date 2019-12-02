using KnewinAPI.Models;
using System;
using System.Collections.Generic;

namespace KnewinAPI.Services.Interface
{
    public interface ICityService
    {
        List<City> GetAll();
        City GetByName(string name);
        City GetById(Guid id);
        List<City> GetByBorder(string name);
        int Create(City city);
        bool CityExists(string name);
        int SumPopulation(Guid[] ids);
        void Update(Guid id, City city);
    }
}
