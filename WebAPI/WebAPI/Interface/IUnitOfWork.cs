using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Interface;

namespace WebAPI.Interface
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository {get;}
    
        IPropertyRepository PropertyRepository{get;}
        IUserRepository UserRepository {get;}
        // IUnitOfWork UnitOfWork {get;}

        IPropertyTypeRepository PropertyTypeRepository{get;}

        IFurnishingTypeRepository FurnishingTypeRepository{get;}
        Task<bool> SaveAsync();
    }
}