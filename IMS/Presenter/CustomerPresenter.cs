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
    public class CustomerPresenter
    {
        private ICustomerView view;
        private ICustomerRepository repository;
        private BindingSource customerBindingSource;
        private IEnumerable<CustomerModel> customerList;

        //Constructor
        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            this.customerBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler method to view events
            this.view.SearchEvent += SearchCustomer;
            this.view.AddNewEvent += AddNewCustomer;
            this.view.EditEvent += LoadSelectedCustomerToEdit;
            this.view.DeleteEvent += DeleteSelectedCustomer;
            this.view.SaveEvent += SaveCustomer;
            this.view.CancelEvent += CancelAction;

            //Set product binding source
            this.view.SetCustomerListBindingSource(customerBindingSource);

            //Load data to the product list
            LoadAllCustomerList();

            //Show View
            this.view.Show();
        }

        private void LoadAllCustomerList()
        {
            customerList = repository.GetAll();
            customerBindingSource.DataSource = customerList;  //Set data source.
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFeilds();
            view.IsEdit = false;
        }

        private void SaveCustomer(object sender, EventArgs e)
        {
            var model = new CustomerModel();
            model.Id = Convert.ToInt32(view.Id);
            model.Name = view.Name;
            model.PhoneNumber = view.PhoneNumber;
            model.Email = view.Email;
            model.Address = view.Address;

            try
            {
                new Common.ModelDataValidation().Validate(model);
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
                view.IsSuccessful = true;
                LoadAllCustomerList();
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
            view.PhoneNumber = "";
            view.Email = "";
            view.Address = "";
        }

        private void DeleteSelectedCustomer(object sender, EventArgs e)
        {
            try
            {
                var product = (CustomerModel)customerBindingSource.Current;
                repository.Delete(product.Id);
                view.Message = "Customer Deleted Sucessfully";
                LoadAllCustomerList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error occured could not delete customer";
            }
        }

        private void LoadSelectedCustomerToEdit(object sender, EventArgs e)
        {
            var customer = (CustomerModel)customerBindingSource.Current;
            view.Id = customer.Id.ToString();
            view.Name = customer.Name;
            view.PhoneNumber = customer.PhoneNumber;
            view.Email = customer.Email;
            view.Address = customer.Address.ToString();
            view.IsEdit = true;
        }

        private void AddNewCustomer(object sender, EventArgs e)
        {
            var model = new CustomerModel();
            model.Id = Convert.ToInt32(view.Id);
            model.Name = view.Name;
            model.PhoneNumber = view.PhoneNumber;
            model.Email = view.Email;
            model.Address = view.Address;
            if (view.IsEdit)
            {
                repository.Update(model);
                view.Message = "Customer updated successfuly";

            }
            else
            {

                repository.Add(model);
                view.Message = "Customer added successfuly";
            }
            view.IsEdit = false;
            LoadAllCustomerList();
        }

        private void SearchCustomer(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                customerList = repository.GetByValue(this.view.SearchValue);
            else customerList = repository.GetAll();
            customerBindingSource.DataSource = customerList;
        }
    }

}
