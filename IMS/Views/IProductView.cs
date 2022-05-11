using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Views
{
    public interface IProductView
    {
        //Properties - Field
        string Id { get; set ; }
        string Name { get; set; }
        string Description { get; set; }
        string Category { get; set; }

        string Quantity { get; set; }

        string Price { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetProductListBindingSource(BindingSource productList);
        void Show(); //Optional

    }
}
