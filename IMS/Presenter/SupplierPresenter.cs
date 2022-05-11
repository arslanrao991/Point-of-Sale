using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Views;
using IMS.Models;
using System.Windows.Forms;

namespace IMS.Presenter
{
    public class SupplierPresenter
    {
        private ISupplierView view;
        private ISupplierRepository repository;
        private BindingSource supplierBindingSource;
        private IEnumerable<SupplierModel> supplierList;

        //Constructor
        public SupplierPresenter(ISupplierView view, ISupplierRepository repository)
        {
            this.supplierBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler method to view events
            this.view.SearchEvent += SearchSupplier;
            this.view.AddNewEvent += AddNewSupplier;
            this.view.EditEvent += LoadSelectedSupplierToEdit;
            this.view.DeleteEvent += DeleteSelectedSupplier;
            this.view.SaveEvent += SaveSupplier;
            this.view.CancelEvent += CancelAction;

            //Set product binding source
            this.view.SetSupplierListBindingSource(supplierBindingSource);

            //Load data to the product list
            LoadAllCustomerList();

            //Show View
            this.view.Show();
        }

        private void LoadAllCustomerList()
        {
            //throw new NotImplementedException();
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveSupplier(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedSupplier(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedSupplierToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewSupplier(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchSupplier(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                supplierList = repository.GetByValue(this.view.SearchValue);
            else supplierList = repository.GetAll();
            supplierBindingSource.DataSource = supplierList;
        }
    }
}
