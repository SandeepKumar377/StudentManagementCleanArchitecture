using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Repository
{
    public interface IGenericRepository<T>: IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter=null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy=null!,
            string includeProperties=""
            );
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void DeleteById(object id);
        void Delete(T entity);
        T DeleteAsync(T entity);
        void Update(T entity);
        T UpdateAsync(T entity);
    } 
}
