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
        }

        private void ShowProductView(object sender, EventArgs e)
        {
            IProductView view = Form1.GetInstance((Form0) mainView);
            IProductRepository repo = new ProductRepository(sqlConnectionString);
            new ProductPresenter(view, repo);
        }
    }
}
