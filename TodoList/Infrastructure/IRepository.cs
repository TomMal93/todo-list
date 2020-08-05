using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace TodoList.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<IEnumerable<T>> GetAll(int page);
        Task<IPagedList<T>> GetPage(int page);
        Task<IPagedList<T>> GetPage(int page, Expression<Func<T, bool>> where);
    }
}
