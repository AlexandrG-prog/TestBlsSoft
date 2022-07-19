using BLL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Abstract
{
    /// <summary>
    /// Сервис доступа к данным
    /// </summary>
    public interface IDataProviderService
    {
        /// <summary>
        /// Звездные системы
        /// </summary>
        IQueryable<StarSystemViewModel> StarSystems { get; }

        /// <summary>
        /// Космические объекты
        /// </summary>
        IQueryable<SpaceObjectViewModel> SpaceObjects { get; }
    }
}
