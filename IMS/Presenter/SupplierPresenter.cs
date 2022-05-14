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
            LoadAllSupplierList();

            //Show View
            this.view.Show();
        }

        private void LoadAllSupplierList()
        {
            supplierList = repository.GetAll();
            supplierBindingSource.DataSource = supplierList;  //Set data source.
        }
        private void CleanViewFeilds()
        {
            view.Id = "";
            view.Name = "";
            view.PhoneNumber = "";
            view.Email = "";
            view.Address = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFeilds();
            view.IsEdit = false;
        }

        private void SaveSupplier(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedSupplier(object sender, EventArgs e)
        {
            try
            {
                var product = (SupplierModel)supplierBindingSource.Current;
                repository.Delete(product.Id);
                view.Message = "Product Deleted Sucessfully";
                LoadAllSupplierList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error occured could not delete supplier";
            }
        }

        private void LoadSelectedSupplierToEdit(object sender, EventArgs e)
        {
            var supplier = (SupplierModel)supplierBindingSource.Current;
            view.Id = supplier.Id.ToString();
            view.Name = supplier.Name;
            view.PhoneNumber = supplier.PhoneNumber;
            view.Email = supplier.Email;
            view.Address = supplier.Address.ToString();
            view.IsEdit = true;
        }

        private void AddNewSupplier(object sender, EventArgs e)
        {
            var model = new SupplierModel();
            model.Id = Convert.ToInt32(view.Id);
            model.Name = view.Name;
            model.PhoneNumber = view.PhoneNumber;
            model.Email = view.Email;
            model.Address = view.Address;
            if (view.IsEdit)
            {
                repository.Update(model);
                view.Message = "Supplier updated successfuly";

            }
            else
            {

                repository.Add(model);
                view.Message = "Supplier added successfuly";
            }
            view.IsEdit = false;
            LoadAllSupplierList();
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
