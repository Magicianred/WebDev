using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{ // Bu interfaceleri istediğimiz bütün projelerimizde kullanılabilir.
    public interface IEntityRepository<T> where T : class, IEntity, new() // Generic Constrain denir 
        // IEntity nesneyi imzaladığımız bir interface
        /*
         * Crud operasyonlarımızı gerçekleştirecek
         * Get Bir filtreleme yapacak
         * GetList ile birden fazla nesneyi listeleyecez         
         */
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null); 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
