using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review.Contract;
using Review.Model.Entities;
using Review.Repository.Context;
using Review.Repository.GenericRepository;
using Review.Repository.UnitOfWork;

namespace Review.Service
{
    public class ProductService : IProductService
    {

        public IUnitOfWork UnitOfWork { get; set; }
        public IGenericRepository<Product> ProductRepository { get; set; }

        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> productRepository)
        {
            UnitOfWork = unitOfWork;
            ProductRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await ProductRepository.GetQuery().ToListAsync();
        }
    }
}
