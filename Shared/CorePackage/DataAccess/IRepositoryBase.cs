using CorePackage.Entities;
using System.Linq.Expressions;

namespace CorePackage.DataAccess
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void UpdateById(Expression<Func<TEntity, bool>> filter, TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
    }
}