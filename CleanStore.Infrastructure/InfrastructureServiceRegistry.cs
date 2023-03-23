
using CleanStore.Application.Contracts.Infrastructure;
using CleanStore.Application.Contracts.Persistence;
using CleanStore.Application.Models;
using CleanStore.Infrastructure.Context;
using CleanStore.Infrastructure.Email;
using CleanStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanStore.Infrastructure
{
    public static class InfrastructureServiceRegistry
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
