using BLL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Abstract
{
    /// <summary>
    /// Методы для работы со звездными системами
    /// </summary>
    public interface IStarSystemManagerService
    {
        void Add(StarSystemViewModel item);
        void Edit(StarSystemViewModel item);
        void Delete(StarSystemViewModel item);
    }
}
