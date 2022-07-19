using DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Космический объект
    /// </summary>
    public class SpaceObject : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Diameter { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int IsCenterOfGravity { get; set; }
        [Required]
        public int StarSystemId { get; set; }

        /// <summary>
        /// Звездная система
        /// </summary>
        [ForeignKey("StarSystemId")]
        public virtual StarSystem StarSystem { get; set; }
    }
}
