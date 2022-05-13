using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface ISalesRepository
    {
        void Add(SalesProductModel sales);
        void Update(SalesModel sales);
        void Delete(int salesId);
        IEnumerable<SalesModel> GetAll();

        IEnumerable<SalesModel> GetByValue(string value);
        IEnumerable<SalesModel> FindByName(string name);
        IEnumerable<SalesModel> FindById(string id);
        IEnumerable<SalesModel> FindByCategory(string category);
    }
}
