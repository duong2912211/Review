using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
     public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetEntities();
        IEnumerable<TEntity> GetEntities(string storeName);
        TEntity GetEntityById(Guid entityId);
        TEntity GetEntityByCode(string entityCode);
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(Guid entityId);
        TEntity GetEntityByProperty(TEntity entity, PropertyInfo property);
    }
}
