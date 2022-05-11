using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface IProductRepository
    {
        void Add(ProductsModel product);
        void Update(ProductsModel product);
        void Delete(int productId);
        IEnumerable<ProductsModel> GetAll();

        IEnumerable<ProductsModel> GetByValue(string value);
        IEnumerable<ProductsModel> FindByName(string name);
        IEnumerable<ProductsModel> FindById(string id);
        IEnumerable<ProductsModel> FindByCategory(string category);

    }
}
