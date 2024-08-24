using EticaretApi.Domain.Entities;
using EticaretApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Persistence.Contexts
{
    public class EticaretApiDbContext : DbContext
    {
        public EticaretApiDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişiklillerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update edilen opersoyunlarda Track edilen verileri yakalayıp elde etmemizi sağlar. 
            var datas =ChangeTracker
                .Entries<BaseEntity>();
                
            foreach (var data in datas)
            {
                //_ = data.State switch
                //{
                //    EntityState.Added => data.Entity.CreatedAt = DateTime.Now,
                //    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                //    _ =>{ }
                //};
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedAt = DateTime.Now;
                }
                else if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
