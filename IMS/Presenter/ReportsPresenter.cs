using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Models;
using IMS.Views;
using IMS._Repositories;

namespace IMS.Presenter
{
    public class ReportsPresenter
    {
        private IReportsView view;
        private IReportsRepository repository;
        private BindingSource ReportsBindingSource;
        private IEnumerable<CReportsModel> customerList;
        private IEnumerable<PReportsModel> productList;

        public ReportsPresenter(IReportsView view, IReportsRepository repository)
        {
            Console.Write("ReportsPresenter Created... ");
            this.view = view;
            this.repository = repository;
            this.ReportsBindingSource = new BindingSource();

            //Subscribe event handler method to view events
            this.view.SaveEvent += SaveReports;
            this.view.CancelEvent += CancelReports;
            this.view.AddProdEvent += AddProductList;
            this.view.AddCustEvent += AddCustList;


            //Set product binding source
            this.view.SetReportListBindingSource(ReportsBindingSource);

            //Load data to the product list
            LoadAllPReportsList();
            //Load data to the customer list
            LoadAllCReportsList();

            //Show View
            this.view.Show();
        }
        private void LoadAllCReportsList()
        {
            customerList = repository.GetCustomerList();
            ReportsBindingSource.DataSource = customerList;  //Set data source.
        }
        private void LoadAllPReportsList()
        {
            productList = repository.GetProductList();
            ReportsBindingSource.DataSource = productList;  //Set data source.
        }
        private void AddProductList(object sender, EventArgs e)
        {
            productList = repository.GetProductList();
            ReportsBindingSource.DataSource = productList;  //Set data source.
        }
        private void AddCustList(object sender, EventArgs e)
        {
            customerList = repository.GetCustomerList();
            ReportsBindingSource.DataSource = customerList;  //Set data source.
        }
        private void SaveReports(object sender, EventArgs e)
        {
            //NotImplementedException;
        }
        private void CancelReports(object sender, EventArgs e)
        {
            CleanViewFeilds();
        }
        private void CleanViewFeilds()
        {
            view.Id = "";
            view.Name = "";
            view.Sales = "";
        }

    }
}
