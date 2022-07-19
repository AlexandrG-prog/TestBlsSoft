using BLL.Enums;
using BLL.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace BLL.ValidationAttributes
{
    public class TypeCenterOfGravityAttribute : ValidationAttribute
    {
        public TypeCenterOfGravityAttribute()
        {
            ErrorMessage = "Центром масс может быть космический объект с типом звезда, черная дыра!";
        }
        public override bool IsValid(object value)
        {
            SpaceObjectViewModel s = value as SpaceObjectViewModel;

            if (s.Type != (int)TypeSpaceObjectEnum.BlackHole && s.Type != (int)TypeSpaceObjectEnum.Star && s.IsCenterOfGravity)
            {
                return false;
            }

            return true;
        }
    }
}
