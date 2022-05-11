using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;

namespace IMS._Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        private string sqlConnectionString;

        public SupplierRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public void Add(ProductsModel supplier)
        {
            throw new NotImplementedException();
        }

        public void Delete(int supplierId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> FindByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductsModel supplier)
        {
            throw new NotImplementedException();
        }
    }
}
