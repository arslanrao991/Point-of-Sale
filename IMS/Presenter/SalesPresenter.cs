using IMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;
using IMS._Repositories;
using System.Windows.Forms;

namespace IMS.Presenter
{
    public class SalesPresenter
    {
        private ISalesView view;
        private ISalesRepository repository;
        private BindingSource salesBindingSource;
        private IEnumerable<SalesModel> salesList;

        //Constructor
        public SalesPresenter(ISalesView view, ISalesRepository repository)
        {
            this.salesBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler method to view events
            this.view.SearchEvent += SearchCustomer;
            this.view.AddNewEvent += AddNewCustomer;
            this.view.UpdateEvent += UpdateProductFromList;
            this.view.DeleteEvent += DeleteSelectedCustomer;
            this.view.ProcessEvent += ProcessSales;
            this.view.CancelEvent += CancelAction;

            //Set product binding source
            this.view.SetCustomerListBindingSource(salesBindingSource);

            //Load data to the product list
            LoadAllSalesList();

            //Show View
            this.view.Show();
        }

        private void LoadAllSalesList()
        {
            //throw new NotImplementedException();
        }

        private void SearchCustomer(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void AddNewCustomer(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            IEnumerable<SalesModel> salesList;
        }

        private void UpdateProductFromList(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedCustomer(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ProcessSales(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CancelAction(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
