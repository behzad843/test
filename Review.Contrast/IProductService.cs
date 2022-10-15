using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review.Model.Entities;
using Review.Repository.Context;

namespace Review.Contract
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
    }
}
