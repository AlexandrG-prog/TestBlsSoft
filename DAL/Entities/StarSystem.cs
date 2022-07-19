using DAL.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// Звездная система
    /// </summary>
    public class StarSystem : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Список космических объектов в звездной системе
        /// </summary>
        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }
    }
}
