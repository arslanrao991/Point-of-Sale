using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Views;
using IMS.Models;
using IMS._Repositories;

namespace IMS.Presenter
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string  sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowProductView += ShowProductView;
            this.mainView.ShowCustomerView += ShowCustomerView;
            this.mainView.ShowSupplierView += ShowSupplierView;
            
        }

        private void ShowProductView(object sender, EventArgs e)
        {
            IProductView view = Form1.GetInstance((Form0) mainView);
            IProductRepository repo = new ProductRepository(sqlConnectionString);
            new ProductPresenter(view, repo);
        }

        private void ShowCustomerView(object sender, EventArgs e)
        {
            ICustomerView view = Form2.GetInstance((Form0)mainView);
            ICustomerRepository repo = new CustomerRepository(sqlConnectionString);
            new CustomerPresenter(view, repo);
        }

        private void ShowSupplierView(object sender, EventArgs e)
        {
            ISupplierView view = Form3.GetInstance((Form0)mainView);
            ISupplierRepository repo = new SupplierRepository(sqlConnectionString);
            new SupplierPresenter(view, repo);
        }
    }
}
