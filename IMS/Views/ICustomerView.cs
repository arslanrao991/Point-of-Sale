using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Views
{
    public interface ICustomerView
    {
        //Properties - Field
        string Id { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }
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
        void SetCustomerListBindingSource(BindingSource customerList);
        void Show(); //Optional
    }
}
