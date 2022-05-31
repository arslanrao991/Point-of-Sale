using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Views
{
    public interface IMainView
    {
        event EventHandler ShowProductView;
        event EventHandler ShowCustomerView;
        event EventHandler ShowSupplierView;
        event EventHandler ShowSalesView;
        event EventHandler ShowReportsView;
    }
}
