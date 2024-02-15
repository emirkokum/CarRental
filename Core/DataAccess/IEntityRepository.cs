using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Generic Repository using
    // generic constarint => Filter : using where on T
    // class : Reference Type
    // IEntity => It can be IEntity or its baby class
    // new() => It must be newable
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        // filter = null => it can be filter or not; if there is no filter get all datas
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
