namespace Base.EF.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Получение запроса по объекту.
        /// </summary>
        /// <returns>Коллекцию объектов типа IQueryable</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Получение объекта.
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Экземпляр объекта</returns>
        T Get(long id);        

        /// <summary>
        /// Сохранить изменения объекта.
        /// </summary>
        /// <param name="value">Измененный объект</param>
        void Update(T value);

        /// <summary>
        /// Cоздание объекта.
        /// </summary>
        /// <param name="value">Создаваемый объект</param>
        // 
        void Create(T value);

        ///// <summary>
        ///// Cоздание объекта.
        ///// </summary>
        ///// <param name="value">Создаваемые объекты</param>
        //void Create(List<T> values);

        /// <summary>
        /// Удаление по id.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого объекта</param>
        void Delete(long id);

        /// <summary>
        /// Сохранение изменений.
        /// </summary>
        void Save();
    }
}
