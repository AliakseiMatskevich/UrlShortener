using Microsoft.EntityFrameworkCore;
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
            entity.DateCreated = DateTime.UtcNow;
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetEntities()
        {
            return _context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entities = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entities;

        }
    }
}
