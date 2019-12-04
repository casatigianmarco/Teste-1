using KnewinAPI.Models;
using KnewinAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;

namespace Knewin.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public ICityService CityService { get; }
        public CityController(ICityService cityService)
        {
            CityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cities = CityService.GetAll();
                if (cities == null)
                {
                    return NotFound();
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var cities = CityService.GetById(id);
                if (cities == null)
                {
                    return NotFound();
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var cities = CityService.GetByName(name);
                if (cities == null)
                {
                    return NotFound();
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetByBorder(string name)
        {
            try
            {
                var cities = CityService.GetByBorder(name);
                if (cities == null)
                {
                    return NotFound();
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] City city)
        {
            try
            {
                CityService.Create(city);
                return Ok(new { result = "Incluida com sucesso."});
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostSumPopulation([FromBody] Guid[] cities)
        {
            try
            {
                var result = CityService.SumPopulation(cities);
                return Ok(new { result = result + " habitantes." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            try
            {
                CityService.Update(id, city);
                return Ok(new { result = "Atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}