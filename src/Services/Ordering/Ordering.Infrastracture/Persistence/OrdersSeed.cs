using Microsoft.Extensions.Logging;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.infrastructure.Persistence {
    public class OrderSeed {
        public static async Task SeedAsync(OrderContext orderContext) {
            
            if (!orderContext.Orders.Any()) {
                
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                
                await orderContext.SaveChangesAsync();
                 
                Console.WriteLine($"Seed database associated with context {typeof(OrderContext).Name}");
            }
     
            
        }

        private static IEnumerable<Order> GetPreconfiguredOrders() {
            var userId = Guid.NewGuid() + "";
            return new List<Order>
            {
               
                new Order() {UserId  = userId , FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "ezozkme@gmail.com", 
                    AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350 }
            };
        }
    }
}