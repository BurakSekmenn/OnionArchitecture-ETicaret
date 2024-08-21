using EticaretApi.Application.Repositories;
using EticaretApi.Domain.Entities.Common;
using EticaretApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Persistence.Repositories
{
    //base entity marker pattern olayından geliyor burası
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
         readonly EticaretApiDbContext _context; // IOC container belirleyeceğiz daha 

        public ReadRepository(EticaretApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        
        }

       

       
    }
}
