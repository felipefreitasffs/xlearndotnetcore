using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Xlearn.Models;

namespace Xlearn.Repository {
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);
        void Insert(ref TEntity entity);
        bool Update(TEntity entity);
        bool Delete(string id);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
