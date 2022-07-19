using BLL.Services.Abstract;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Implementation
{
    public class StarSystemManagerService : IStarSystemManagerService
    {
        private IRepository _repository;

        public StarSystemManagerService(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(StarSystemViewModel item)
        {
            _repository.Save<StarSystem>(item.FillToEntity());
        }

        public void Edit(StarSystemViewModel item)
        {
            _repository.Save<StarSystem>(item.FillToEntity());
        }

        public void Delete(StarSystemViewModel item)
        {
            _repository.Delete<StarSystem>(item.FillToEntity());
        }
    }
}
