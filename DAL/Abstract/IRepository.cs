using DAL.Entities;
using DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Abstract
{
    public interface IRepository
    {
        /// <summary>
        /// Звездные системы
        /// </summary>
        IQueryable<StarSystem> StarSystems { get; }

        /// <summary>
        /// Космические объекты
        /// </summary>
        IQueryable<SpaceObject> SpaceObjects { get; }

        /// <summary>
        /// Сохранение сущности в БД
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        /// <param name="saveChanges">Выполнить сохранение изменений в бд после выполнения</param>
        void Save<T>(T entity, bool saveChanges = true) where T : Entity;

        /// <summary>
        /// Удаление сущности из БД
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        /// <param name="saveChanges">Выполнить сохранение изменений в бд после выполнения</param>
        void Delete<T>(T entity, bool saveChanges = true) where T : Entity;

        /// <summary>
        /// Возвращает запись для доступ к сведениям об отслеживанию изменений и операциям для сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        /// <returns></returns>
        EntityEntry<T> GetEntryEntity<T>(T entity) where T : Entity;
    }
}
