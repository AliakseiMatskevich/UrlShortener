using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.ApplicationCore.Entities.Abstracts;
using UrlShortener.ApplicationCore.Interfaces;

namespace UrlShortener.Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly UrlShortenerContext _context;
        public EFRepository(UrlShortenerContext context) 
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetList()
        {
            return _context.Set<T>();
        }
    }
}
