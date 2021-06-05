using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data {
    public class OrderContext : DbContext {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) {
        }
        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            foreach (var item in ChangeTracker.Entries<BaseModel>()) {
                switch (item.State) {
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.Now;
                        item.Entity.LastModifiedBy = "user";
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedBy = "user";
                        item.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
