using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface ISalesRepository
    {
        int ProcessSale(DataTable sale, string phone, double total_bill, double received_amounts);
        void Update(SalesModel sales);
        int ReturnSale(int salesId, int product_id, int quantity, int is_bill_paid);
        IEnumerable<SalesModel> GetAll();

        IEnumerable<SalesModel> GetByValue(string value);
        IEnumerable<SalesModel> FindByName(string name);
        IEnumerable<SalesModel> FindById(string id);
        IEnumerable<SalesModel> FindByCategory(string category);
    }
}
