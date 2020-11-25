using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BaseEntity = EnglishReader.Core.Entities.BaseEntity;

namespace EnglishReader.Core.Context.EntityFramework
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
