using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Review.Model.Entities;

namespace Review.Repository.Context
{
    public class InitData
    {
        public static void Initialize(IServiceProvider ServiceProvider)
        {
            using (var context =
                   new ReviewContext(ServiceProvider.GetRequiredService<DbContextOptions<ReviewContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(new Product()
                {
                    Id = 1,
                    Name = "Samsung",
                    Description = "Samsung A10",
                    Price = 2000
                },
                new Product()
                {
                    Id = 2,
                    Name = "Iphone",
                    Description = "Iphone 6s",
                    Price = 2500
                });

                context.SaveChanges();
            }
        }
    }
}
