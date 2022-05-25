using IMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;
using IMS._Repositories;
using System.Windows.Forms;
using System.Data;

namespace IMS.Presenter
{
    public class SalesPresenter
    {
        private ISalesView view;
        private ISalesRepository repository;
        private BindingSource salesBindingSource;
        private BindingSource prodductBindindSource;
        private BindingSource accuredPaymentBindingSource;
        private DataTable table;

        private IEnumerable<SalesModel> salesList;
        private IEnumerable<AccuredPaymentsModel> accuredPayments;

        //Constructor
        public SalesPresenter(ISalesView view, ISalesRepository repository)
        {
            this.salesBindingSource = new BindingSource();
            this.prodductBindindSource = new BindingSource();
            this.accuredPaymentBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");

            //Subscribe event handler method to view events
            this.view.SearchEvent += SearchSale;
            this.view.AddNewEvent += AddProductToCart;
            this.view.UpdateEvent += UpdateCart;
            this.view.ProcessEvent += ProcessSales;
            this.view.CancelEvent += CancelAction;
            this.view.ReturnSales += ReturnSales;
            this.view.AccuredPayment += AccuredPayment;
            this.view.SearchEventForAccuredPayments += SearchEventForAccuredPayments;


            //Set product binding source
            this.view.SetSalesListBindingSource(salesBindingSource);
            this.view.SetCartProductsBindingSource(prodductBindindSource);
            this.view.SetAccuredPaymentBindingSource(accuredPaymentBindingSource);

            //Load data to the product list
            LoadAllSalesList();

            //Show View
            this.view.Show();
        }

        private void SearchEventForAccuredPayments(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValueAccuredPayment);
            if (emptyValue == false)
                accuredPayments = repository.GetByValueAccuredPayments(this.view.SearchValueAccuredPayment);
            else accuredPayments = repository.GetAllAccuredPayments();
            accuredPaymentBindingSource.DataSource = accuredPayments;
        }

        private void AccuredPayment(object sender, EventArgs e)
        {
            string phone = view.AccuredPhoneNo;
            double payment = Convert.ToDouble(view.AccuredAmount);
            repository.AddAccuredPayment(phone, payment);
        }

        private void ReturnSales(object sender, EventArgs e)
        {
            int sales_id = Convert.ToInt32(view.Return_Sales_Id);
            int product_id = Convert.ToInt32(view.Return_Product_Id);
            int quantity = Convert.ToInt32(view.Return_Quantity);
            bool is_paid_sale = view.Return_Is_Bill_Paid;
            int paid_sale;
            if (is_paid_sale)
                paid_sale = 1;
            else
                paid_sale = 0;

            repository.ReturnSale(sales_id, product_id, quantity, paid_sale);

        }

        private void LoadAllSalesList()
        {
            salesList = repository.GetAll();
            salesBindingSource.DataSource = salesList; 

            accuredPayments = repository.GetAllAccuredPayments();
            accuredPaymentBindingSource.DataSource = accuredPayments;

        }

        private void CleanViewFeilds()
        {
            view.Id = "";
            view.Selling_Price = "";
            view.Quantity = "";
            view.PhoneNo = "Phone No";
            view.ReceivedAmount = "received Amount";
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
            int product_id = Convert.ToInt32(view.Id);
            int quantity = Convert.ToInt32(view.Quantity);
            int price = Convert.ToInt32(view.Selling_Price);
            table.Rows.Add(product_id, quantity, price);
            prodductBindindSource.DataSource = table;
        }

        private void UpdateCart(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ProcessSales(object sender, EventArgs e)
        {
            string phone = (string)view.PhoneNo;
            if (phone == "Phone No" || phone == "")
                phone = "0000";
            string rc_amount = (string)(view.ReceivedAmount);
            double received_amount;
            if (rc_amount == "Received Amount" || rc_amount == "")
                received_amount = 0;
            else 
                received_amount = Convert.ToDouble(rc_amount);
            double total_bill = 0;
            for(int i=0;i<table.Rows.Count;i++)
            {
                total_bill += Convert.ToDouble(table.Rows[i]["Price"]) * Convert.ToInt32(table.Rows[i]["Quantity"]);
            }
            int isSuccessfull=repository.ProcessSale(table, phone, total_bill, received_amount);

            if (isSuccessfull == 1)
            {
                table.Clear();
                view.PhoneNo = "Phone No";
                view.ReceivedAmount = "Received Amount";
                table.Rows.Clear();
            }
            
                
        }

        private void CancelAction(object sender, EventArgs e)
        {
            table.Clear();
            view.PhoneNo = "Phone No";
            view.ReceivedAmount = "Received Amount";
        }
    }
}
