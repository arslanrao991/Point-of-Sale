using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText;
using IMS.Models;
namespace IMS.Views
{
    public interface IReportsView
    {

        //Properties - Field
        string Id { get; set; }
        string Name { get; set; }
        string Sales { get; set; }
        
        //Events
        event EventHandler SearchEvent;
        event EventHandler AddProdEvent;
        event EventHandler AddCustEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetPReportListBindingSource(BindingSource reportList);
        void SetCReportListBindingSource(BindingSource reportList );
        void setCustListPDF(IEnumerable<CReportsModel> customerList);
        void setProdListPDF(IEnumerable<PReportsModel> productList);
        void Show(); //Optional
    }
}
