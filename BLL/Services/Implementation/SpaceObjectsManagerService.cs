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
    public class SpaceObjectsManagerService : ISpaceObjectsManagerService
    {
        private IRepository _repository;
        private IChangeSpaceObject _changeSpaceObject;

        public SpaceObjectsManagerService(IRepository repository, IChangeSpaceObject changeSpaceObject)
        {
            _repository = repository;
            _changeSpaceObject = changeSpaceObject;
        }

        public void Add(SpaceObjectViewModel item)
        {
            _changeSpaceObject.ChangeStarSystemChangeCenterOfGravity(item.FillToEntity());
        }

        public void Edit(SpaceObjectViewModel item)
        {
            _changeSpaceObject.ChangeStarSystemChangeCenterOfGravity(item.FillToEntity());
        }

        public void Delete(SpaceObjectViewModel item)
        {
            _repository.Delete<SpaceObject>(item.FillToEntity());
        }
    }
}
