using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ViewModels
{
    public class StarSystemViewModel : IMappingEntity<StarSystem>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя системы")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите возраст системы")]
        public int Age { get; set; }

        /// <summary>
        /// Центры масс
        /// </summary>
        public IEnumerable<SpaceObjectViewModel> CentersOfGravity { get; set; }

        /// <summary>
        /// Список космических объектов в звездной системе
        /// </summary>
        public IEnumerable<SpaceObjectViewModel> SpaceObjects { get; set; }

        public StarSystem FillToEntity()
        {
            var entity = new StarSystem()
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age
            };

            return entity;
        }
    }
}
