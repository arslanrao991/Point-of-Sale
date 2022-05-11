using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface ISupplierRepository
    {
        void Add(ProductsModel supplier);
        void Update(ProductsModel supplier);
        void Delete(int supplierId);
        IEnumerable<SupplierModel> GetAll();
        IEnumerable<SupplierModel> GetByValue(string value);
        IEnumerable<SupplierModel> FindByName(string name);
        IEnumerable<SupplierModel> FindById(string id);
        IEnumerable<SupplierModel> FindByCategory(string category);
    }
}
