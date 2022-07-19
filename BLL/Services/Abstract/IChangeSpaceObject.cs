using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Abstract
{
    /// <summary>
    /// Изменение у космического объекта свойств
    /// </summary>
    public interface IChangeSpaceObject
    {
        /// <summary>
        /// Изменение звездной системы или центра масс
        /// </summary>
        /// <param name="item">космический объект</param>
        void ChangeStarSystemChangeCenterOfGravity(SpaceObject item);
    }
}
