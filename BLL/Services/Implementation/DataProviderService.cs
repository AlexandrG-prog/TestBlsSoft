using BLL.Enums;
using BLL.Services.Abstract;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Implementation
{
    public class DataProviderService : IDataProviderService
    {
        private IRepository _repository;

        public DataProviderService(IRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<StarSystemViewModel> StarSystems
        {
            get
            {
                return _repository.StarSystems.OrderBy(x => x.Name).Select(x => new StarSystemViewModel()
                {
                    Id = x.Id,
                    Age = x.Age,
                    Name = x.Name,
                    SpaceObjects = x.SpaceObjects.Select(y => new SpaceObjectViewModel()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Age = y.Age,
                        Diameter = y.Diameter,
                        IsCenterOfGravity = y.IsCenterOfGravity == 1,
                        StarSystemId = y.StarSystemId,
                        Type = y.Type,
                        Weight = y.Weight
                    }),
                    CentersOfGravity = x.SpaceObjects.Where(z => z.IsCenterOfGravity == 1).Select(y => new SpaceObjectViewModel()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Age = y.Age,
                        Diameter = y.Diameter,
                        IsCenterOfGravity = y.IsCenterOfGravity == 1,
                        StarSystemId = y.StarSystemId,
                        Type = y.Type,
                        Weight = y.Weight
                    })
                });
            }
        }

        public IQueryable<SpaceObjectViewModel> SpaceObjects
        {
            get
            {
                return _repository.SpaceObjects.OrderBy(x => x.Name).Select(y => new SpaceObjectViewModel()
                {
                    Id = y.Id,
                    Name = y.Name,
                    Age = y.Age,
                    Diameter = y.Diameter,
                    IsCenterOfGravity = y.IsCenterOfGravity == 1,
                    CenterOfGravity = y.IsCenterOfGravity == 1 ? "да" : "нет",
                    StarSystemId = y.StarSystemId,
                    Type = y.Type,
                    Weight = y.Weight,
                    StarSystem = new StarSystemViewModel()
                    {
                        Id = y.StarSystem.Id,
                        Age = y.StarSystem.Age,
                        Name = y.StarSystem.Name
                    }
                });
            }
        }
    }
}
