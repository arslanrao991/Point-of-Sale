using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Models;
using IMS.Views;

namespace IMS.Presenter
{
    public class ProductPresenter
    {
        //Fields
        private IProductView view;
        private IProductRepository repository;
        private BindingSource productBindingSource;
        private IEnumerable<ProductsModel> productList;

        //Constructor
        public ProductPresenter(IProductView view, IProductRepository repository)
        {
            this.productBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler method to view events
            this.view.SaveEvent += SearchProduct;
            this.view.AddNewEvent += AddNewProduct;
            this.view.AddNewEvent += LoadSelectedProductToEdit;
            this.view.AddNewEvent += DeleteSelectedProduct;
            this.view.SaveEvent += SaveProduct;
            this.view.CancelEvent += CancelAction;

            //Set product binding source
            this.view.SetProductListBindingSource(productBindingSource);

            //Load data to the product list
            LoadAllProductList();

            //Show View
            this.view.Show();
        }

        private void LoadAllProductList()
        {
            productList = repository.GetAll();
            productBindingSource.DataSource = productList;  //Set data source.
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedProduct(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedProductToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewProduct(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchProduct(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if(emptyValue == false)
                productList = repository.GetByValue(this.view.SearchValue);
            else productList = repository.GetAll();
            productBindingSource.DataSource = productList;
        }
    }
}
