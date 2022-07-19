using BLL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Abstract
{
    /// <summary>
    /// Методы для работы с космическими объектами
    /// </summary>
    public interface ISpaceObjectsManagerService
    {
        void Add(SpaceObjectViewModel item);
        void Edit(SpaceObjectViewModel item);
        void Delete(SpaceObjectViewModel item);
    }
}
