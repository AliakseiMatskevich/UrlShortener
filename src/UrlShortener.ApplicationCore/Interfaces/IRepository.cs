using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.ApplicationCore.Entities.Abstracts;

namespace UrlShortener.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetEntities();
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
    }
}
