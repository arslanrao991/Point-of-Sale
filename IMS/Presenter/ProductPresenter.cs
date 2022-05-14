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
            this.view.SearchEvent += SearchProduct;
            this.view.AddNewEvent += AddNewProduct;
            this.view.EditEvent += LoadSelectedProductToEdit;
            this.view.DeleteEvent += DeleteSelectedProduct;
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
            CleanViewFeilds();
            view.IsEdit = false;
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            var model = new ProductsModel();
            model.Id = Convert.ToInt32(view.Id);
            model.Name = view.Name;
            model.Category = view.Category;
            model.Description = view.Description;
            model.Quantity = Convert.ToInt32(view.Quantity);
            model.PerUnitPrice = Convert.ToDouble(view.Price);

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(view.IsEdit)
                {
                    repository.Update(model);
                    view.Message = "Product updated successfuly";

                }
                else
                {
                    repository.Add(model);
                    view.Message = "Product added successfuly";
                }
                view.IsSuccessful = true;
                LoadAllProductList();
                CleanViewFeilds();

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFeilds()
        {
            view.Id = "";
            view.Name = ""; 
            view.Category = "";
            view.Description="";
            view.Quantity = "";
            view.Price = "";
        }

        private void DeleteSelectedProduct(object sender, EventArgs e)
        {
            try
            {
                var product = (ProductsModel)productBindingSource.Current;
                repository.Delete(product.Id);
                //view.IsSuccessful = true; //Errorrrr
                view.Message = "Product Deleted Sucessfully";
                LoadAllProductList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error occured could not delete Product";
            }
        }

        private void LoadSelectedProductToEdit(object sender, EventArgs e)
        {
            var product = (ProductsModel)productBindingSource.Current;
            view.Id = product.Id.ToString();
            view.Name = product.Name;
            view.Category = product.Category;
            view.Description = product.Description;
            view.Quantity  = product.Quantity.ToString();
            view.Price = product.PerUnitPrice.ToString();
            view.IsEdit = true;

        }

        private void AddNewProduct(object sender, EventArgs e)
        {
            
            var model = new ProductsModel();
            model.Id = Convert.ToInt32(view.Id);
            model.Name = view.Name;
            model.Category = view.Category;
            model.Description = view.Description;
            model.Quantity = Convert.ToInt32(view.Quantity);
            model.PerUnitPrice = Convert.ToDouble(view.Price);
            if (view.IsEdit)
            {
                repository.Update(model);
                view.Message = "Product updated successfuly";

            }
            else
            {
                
                repository.Add(model);
                view.Message = "Product added successfuly";
            }
            view.IsEdit = false;
            LoadAllProductList();

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
