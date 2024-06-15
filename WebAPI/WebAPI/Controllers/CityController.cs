using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Data.Interface;
using WebAPI.Dtos;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    public class CityController : BaseController
    {
     
       
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow,IMapper mapper)
        {
            
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("cities")]
        [AllowAnonymous]
        public async Task<IActionResult>  GetCities()
        {
           var cities =  await uow.CityRepository.GetCitiesAsync();
            
            var citiesDto=mapper.Map<IEnumerable<CityDto>>(cities);
           

            return Ok(citiesDto);
        }
       
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
           
           
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
         public async Task<IActionResult> UpdateCity(int id,CityDto cityDto){
            //var cityFromDb = await uow.CityRepository.FindCity(id);
             var cityFromDb = await uow.CityRepository.FindCity(id);
             if (cityFromDb == null)
             {
                return BadRequest("Update not allowed"); // Or handle the null case appropriately
                 }

            
            cityFromDb.LastUpdatedBy=1;
            //cityFromDb.LastUpdateOn= DateTime.Now;
            mapper.Map(cityDto,cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
         }
         [HttpPut("updateCityName/{id}")]
         public async Task<IActionResult> UpdateCity(int id,CityUpdateDto cityDto){
            //var cityFromDb = await uow.CityRepository.FindCity(id);
             var cityFromDb = await uow.CityRepository.FindCity(id);
             if (cityFromDb == null)
             {
                return NotFound(); // Or handle the null case appropriately
                 }
            
            
            cityFromDb.LastUpdatedBy=1;
            //cityFromDb.LastUpdateOn= DateTime.Now;
            mapper.Map(cityDto,cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
         }


        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }

    }
}
