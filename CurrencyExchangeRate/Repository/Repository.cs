namespace CurrencyExchangeRate.Repository
{
    using Base.EF.Interfaces;
    using CurrencyExchangeRate.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private bool _disposed = false;
        protected readonly ApplicationDbContext Context;

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение запроса по объекту.
        /// </summary>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        /// <summary>
        /// Получение объекта.
        /// </summary>
        public T Get(long id)
        {
            var aa = Context.Set<T>().Find(id);
            return aa;
        }

        /// <summary>
        /// Сохранить изменения объекта.
        /// </summary>
        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Cоздание объекта.
        /// </summary>
        public void Create(T item)
        {
            Context.Set<T>().Add(item);
            Save();
        }

        ///// <summary>
        ///// Cоздание объекта.
        ///// </summary>
        //public void Create(List<T> items)
        //{
        //    if (items.Count == 0)
        //    {
        //        return;
        //    }

        //    var table = _context.Set<T>();

        //    foreach (var item in items)
        //    {
        //        table.Add(item);
        //    }

        //    Save();
        //}

        /// <summary>
        /// Удаление по id.
        /// </summary>
        public void Delete(long id)
        {
            Context.Set<T>().Remove(Get(id));
            Save();
        }

        /// <summary>
        /// Сохранение изменений.
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
