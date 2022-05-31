using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public interface IReportsRepository
    {
        IEnumerable<PReportsModel> GetProductList();
        IEnumerable<CReportsModel> GetCustomerList();

    }
}