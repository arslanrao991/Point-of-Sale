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
            this.view.SearchEvent += SearchSale;
            this.view.AddNewEvent += AddProductToCart;
            this.view.UpdateEvent += UpdateCart;
            this.view.ProcessEvent += ProcessSales;
            this.view.CancelEvent += CancelAction;

            //Set product binding source
            this.view.SetSalesListBindingSource(salesBindingSource);
            this.view.SetCartProductsBindingSource(salesBindingSource);

            //Load data to the product list
            LoadAllSalesList();

            //Show View
            this.view.Show();
        }

        private void LoadAllSalesList()
        {
            salesList = repository.GetAll();
            salesBindingSource.DataSource = salesList;  //Set data source.
        }

        private void SearchSale(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                salesList = repository.GetByValue(this.view.SearchValue);
            else salesList = repository.GetAll();
            salesBindingSource.DataSource = salesList;
        }

        private void AddProductToCart(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            IEnumerable<SalesModel> salesList;
        }

        private void UpdateCart(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
