using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface IDashboardRepository
    {
        int GetNumProducts();

        int GetNumCustomers();
        int GetNumOrders(DateTime startDate, DateTime endDate);

        //IEnumerable<MonthlySalesData> GetMonthlySales();
        IEnumerable<int> MonthlySales();
        IEnumerable<ProductDashboardModel> GetLowStock();
        IEnumerable<PReportsModel> GetProductList();
        IEnumerable<CReportsModel> GetCustomerList();

    }
}
