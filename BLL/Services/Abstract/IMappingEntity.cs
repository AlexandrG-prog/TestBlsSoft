using DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Abstract
{
    /// <summary>
    /// Заполнение сущности
    /// </summary>
    /// <typeparam name="T">сущность</typeparam>
    public interface IMappingEntity<T> where T : Entity
    {
        T FillToEntity();
    }
}
