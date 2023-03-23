
using CleanStore.Domain.Models;
using CleanStore.Infrastructure.Context;
using Microsoft.Extensions.Logging;

namespace CleanStore.Infrastructure.Persistence
{
    public class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILogger<StoreDbContextSeed> logger)
        {
            if (!context.Sellers!.Any())
            {
                context.Sellers!.AddRange(GetPreconfiguredSeller());
                await context.SaveChangesAsync();
                logger.LogInformation("Creating new records to database {context}", typeof(StoreDbContext).Name);
            }
        }

        private static IEnumerable<Seller> GetPreconfiguredSeller()
        {
            return new List<Seller>
            {
                new Seller
                {
                    CreatedBy = "sotalvaroo", Name = "Mercadolibre", Url = "https://www.mercadolibre.com"
                },
                new Seller
                {
                    CreatedBy = "sotalvaroo", Name = "OLX", Url = "https://www.olx.com"
                },
                new Seller
                {
                    CreatedBy = "sotalvaroo", Name = "Aliexpress", Url = "https://www.aliexpress.com"
                },
            };
        }
    }
}
