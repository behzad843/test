using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Review.Contract;
using Review.Repository.Context;
using Review.Repository.GenericRepository;
using Review.Repository.UnitOfWork;
using Review.Service;

namespace Review.Base
{
    public class IocConfig
    {
        public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReviewContext>(options => options.UseInMemoryDatabase(databaseName: "ReviewDB"));
            services.AddScoped(typeof(DbContext), typeof(ReviewContext));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IReviewService), typeof(ReviewService));

            return services;
        }
    }
}
