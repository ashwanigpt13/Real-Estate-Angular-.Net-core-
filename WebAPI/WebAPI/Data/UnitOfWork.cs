using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Interface;
using WebAPI.Data.Repo;
using WebAPI.Interface;

namespace WebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICityRepository CityRepository => new CityRepository(dc);

        public IUserRepository UserRepository => new UserRepository(dc);

        public IPropertyRepository PropertyRepository => 
           new PropertyRepository(dc);

        public IPropertyTypeRepository PropertyTypeRepository=>
            new PropertyTypeRepository(dc);

        public IFurnishingTypeRepository FurnishingTypeRepository=>
         new FurnishingTypeRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync()>0;
        }
    }
}