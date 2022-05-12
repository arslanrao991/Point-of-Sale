using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface ICustomerRepository
    {
        void Add(CustomerModel customer);
        void Update(CustomerModel customer);
        void Delete(int customerId);
        IEnumerable<CustomerModel> GetAll();
        IEnumerable<CustomerModel> GetByValue(string value);
        IEnumerable<CustomerModel> FindByName(string name);
        IEnumerable<CustomerModel> FindById(string id);
        IEnumerable<CustomerModel> FindByCategory(string category);
    }
}
