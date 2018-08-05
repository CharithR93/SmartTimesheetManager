using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TimesheetManagerApp.Core.Repository
{
    interface IRespository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);

        
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity,bool>> expression);
    }
}
