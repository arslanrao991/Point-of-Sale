﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Views
{
    public interface ISalesView
    {
        //Properties - Field
        string Id { get; set; }
        string Quantity { get; set; }
        string Selling_Price { get; set; }
        string Discount { get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        string Return_Sales_Id { get; set; }
        string Return_Product_Id { get; set; }
        string Return_Quantity { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler UpdateEvent;
        event EventHandler DeleteEvent;
        event EventHandler ProcessEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetCustomerListBindingSource(BindingSource customerList);
        void Show(); //Optional
    }
}
