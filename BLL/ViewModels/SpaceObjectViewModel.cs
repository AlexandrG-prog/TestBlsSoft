using BLL.Enums;
using BLL.Services.Abstract;
using BLL.ValidationAttributes;
using DAL.Entities;
using DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModels
{
    [TypeCenterOfGravityAttribute]
    public class SpaceObjectViewModel : IMappingEntity<SpaceObject>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя объекта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите возраст объекта")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Укажите диаметр объекта")]
        public double Diameter { get; set; }

        [Required(ErrorMessage = "Укажите массу объекта")]
        public int Weight { get; set; }
        public int Type { get; set; }
        public bool IsCenterOfGravity { get; set; }
        public string CenterOfGravity { get; set; }

        [Required(ErrorMessage = "Укажите звездную систему объекта")]
        public int StarSystemId { get; set; }

        /// <summary>
        /// Звездная система
        /// </summary>
        public StarSystemViewModel StarSystem { get; set; }

        public SpaceObject FillToEntity()
        {
            var entity = new SpaceObject()
            {
                Id = this.Id,
                Age = this.Age,
                Name = this.Name,
                StarSystemId = this.StarSystemId,
                Type = this.Type,
                Weight = this.Weight,
                IsCenterOfGravity = this.IsCenterOfGravity ? 1 : 0,
                Diameter = this.Diameter
            };

            return entity;
        }
    }
}
