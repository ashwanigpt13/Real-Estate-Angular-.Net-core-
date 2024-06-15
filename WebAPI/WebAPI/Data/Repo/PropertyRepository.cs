//using System;

//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using WebAPI.Interface;

using Microsoft.EntityFrameworkCore;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext dc;

        public PropertyRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddProperty(Property property)
        {
                dc.Properties.Add(property);
        }

        public void DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent)
        {
            var properties= await dc.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.City)
                .Include(p=>p.FurnishingType)
                .Include(p=>p.Photos)
                .Where(p=> p.SellRent==sellRent).ToListAsync();
            return properties;
            }

        public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var properties= await dc.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.City)
                .Include(p=>p.Photos)
                .Include(p => p.FurnishingType)
                .Where(p=> p.Id==id).FirstAsync();
            return properties;        }


        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            var properties = await dc.Properties
                .Include(p => p.Photos)
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            return properties;
        }
    }

}