using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private string sqlConnectionString;

        public CustomerRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public void Add(ProductsModel customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> FindByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductsModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
