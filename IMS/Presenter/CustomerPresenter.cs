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
            throw new NotImplementedException();
        }

        private void SaveCustomer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedCustomer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedCustomerToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewCustomer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
