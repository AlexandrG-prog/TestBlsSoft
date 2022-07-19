using BLL.Services.Abstract;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Implementation
{
    public class ChangeSpaceObject : IChangeSpaceObject
    {
        private IRepository _repository;

        public ChangeSpaceObject(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Изменение звездной системы или центра масс (с сохранением космического объекта)
        /// </summary>
        /// <param name="item">космический объект</param>
        public void ChangeStarSystemChangeCenterOfGravity(SpaceObject item)
        {
            var existItem = _repository.SpaceObjects.FirstOrDefault(x => x.Id == item.Id);

            if (existItem != null)
            {
                var entryEntity = _repository.GetEntryEntity<SpaceObject>(existItem);
                entryEntity.CurrentValues.SetValues(item);

                if (item.IsCenterOfGravity == 1 && (entryEntity.Property(x => x.IsCenterOfGravity).IsModified || entryEntity.Property(x => x.StarSystemId).IsModified))
                    ResetCentersOfGravity(item);

                _repository.Save<SpaceObject>(existItem);
            }
            else
            {
                if (item.IsCenterOfGravity == 1)
                    ResetCentersOfGravity(item);

                _repository.Save<SpaceObject>(item);
            }
        }

        private void ResetCentersOfGravity(SpaceObject item)
        {
            var starSystem = _repository.StarSystems.Include(x => x.SpaceObjects).FirstOrDefault(x => x.Id == item.StarSystemId);

            if (starSystem.SpaceObjects != null)
            {
                foreach (var spaceObject in starSystem.SpaceObjects.Where(x => x.Id != item.Id)?.ToList())
                {
                    spaceObject.IsCenterOfGravity = 0;
                    _repository.Save<SpaceObject>(spaceObject);
                }
            }
        }
    }
}
