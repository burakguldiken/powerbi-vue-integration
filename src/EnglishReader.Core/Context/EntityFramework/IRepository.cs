using EnglishReader.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EnglishReader.Core
{
    public interface IRepository<T> where T : Base
    {
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
