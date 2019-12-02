using KnewinAPI.Infraestruture.Interface.Repository;
using KnewinAPI.Models;
using KnewinAPI.Services.Interface;
using System;
using System.Collections.Generic;

namespace KnewinAPI.Services
{
    public class CityService : ICityService
    {
        public ICityRepository CityRepository;

        public CityService(ICityRepository cityRepository)
        {
            CityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }
        public List<City> GetAll()
        {
            try
            {
                return CityRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public City GetById(Guid id)
        {
            try
            {
                return CityRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City GetByName(string name)
        {
            try
            {
                return CityRepository.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(City city)
        {
            try
            {
                if (city != null && city.Name != string.Empty && CityExists(city.Name))
                {
                    throw new Exception("Cidade já cadastrada.");
                }

                if(city.Name == null || city.Name == string.Empty)
                {
                    throw new Exception("Nome da cidade é necessário.");
                }

                return CityRepository.Create(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CityExists(string name)
        {
            try
            {
                return CityRepository.CityExists(name);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int SumPopulation(Guid[] ids)
        {
            try
            {
                return CityRepository.SumPopulation(ids);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Guid id, City city)
        {
            try
            {
                var update = CityRepository.GetById(id);

                if (city.Name != null)
                {
                    update.Name = city.Name;
                }

                if(city.Population != 0)
                {
                    update.Population = city.Population;
                }

                CityRepository.Update(id, update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<City> GetByBorder(string name)
        {
            try
            {
                List<City> list = new List<City>();
                var borders = CityRepository.GetByBorder(name);
                foreach (var item in borders)
                {
                    list.Add(GetById(item.CityId));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
