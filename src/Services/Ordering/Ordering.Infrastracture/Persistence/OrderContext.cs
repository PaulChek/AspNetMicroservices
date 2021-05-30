using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.infrastructure.Persistence {
    public class OrderContext : DbContext {
        public OrderContext([NotNull] DbContextOptions options) : base(options) {
        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            foreach (var entry in ChangeTracker.Entries<ModelBase>()) {
                if (entry.State == EntityState.Added) {
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedBy = "paul";
                }
                else if (entry.State == EntityState.Modified) {
                    entry.Entity.LastModifiedBy = "check";
                    entry.Entity.UpdateddAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
