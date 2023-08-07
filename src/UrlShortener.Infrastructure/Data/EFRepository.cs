using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EFRepository<T>> _logger;
        public EFRepository(UrlShortenerContext context,
            ILogger<EFRepository<T>> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<T> CreateAsync(T entity)
        {            
            entity.DateCreated = DateTime.UtcNow;
            _context.Add(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Create entity of {entity.GetType().Name} with id = {entity.Id}");
            return entity;
        }

        public IQueryable<T> GetEntities()
        {
            _logger.LogInformation($"Get entities of {typeof(T).Name}");
            return _context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            _logger.LogInformation($"Delete entity of {entity.GetType().Name} with id = {entity.Id}");
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"Create entity of {typeof(T).Name} with id = {id}");
            var entities = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entities;

        }
    }
}
