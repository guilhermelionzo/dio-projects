using System;
using System.Collections.Generic;

namespace TvSeries.Domain.Repositories
{
    public interface IRepository<T>
    {
        IList<T> List();
        T GetById();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        Guid NextId();
    }
}