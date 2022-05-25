using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace IMS.Views
{
    public partial class Form4 : KryptonForm, ISalesView
    {
        
        private bool isEdit;
        private bool isSuccess;
        private string message;
        public string Id 
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; } 
        }
        public string Quantity
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string Selling_Price
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string Discount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SearchValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccessful
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Return_Sales_Id
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public string Return_Product_Id
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }
        public string Return_Quantity
        {
            get { return textBox7.Text; }
            set { textBox7.Text = value; }
        }
        public string ReceivedAmount
        {
            get { return rcTextBox.Text; }
            set { rcTextBox.Text = value; }
        }

        public bool Return_Is_Bill_Paid 
        { 
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = false; } 
        }
        public string PhoneNo
        {
            get { return phTextBox.Text; }
            set { phTextBox.Text = value; }
        }

        public string AccuredPhoneNo
        {
            get { return acPhoneNo.Text; }
            set { acPhoneNo.Text = value; }
        }
        public string AccuredAmount
        {
            get { return acAmount.Text; }
            set { acAmount.Text = value; }
        }

        public string SearchValueAccuredPayment
        {
            get { return acTextBox.Text; }
            set { acTextBox.Text = value; }
        }

        public Form4()
        {
            InitializeComponent();
            AssociateandRaiseViewEvents();
            button5.Click += delegate { this.Close(); };
        }

        private void AssociateandRaiseViewEvents()
        {
            button1.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            button4.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            btnCancel.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
            btnGenerate.Click += delegate { ProcessEvent?.Invoke(this, EventArgs.Empty); };
            button2.Click += delegate { ReturnSales?.Invoke(this, EventArgs.Empty); };
            acBtn1.Click += delegate { AccuredPayment?.Invoke(this, EventArgs.Empty); };
            button3.Click  += delegate { SearchEventForAccuredPayments?.Invoke(this, EventArgs.Empty); };

        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler ProcessEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ReturnSales;
        public event EventHandler AccuredPayment;
        public event EventHandler SearchEventForAccuredPayments;

        public void SetSalesListBindingSource(BindingSource customerList)
        {
            dataGridView.DataSource = customerList;
        }
        public void SetCartProductsBindingSource(BindingSource cartProducts)
        {
            dataGridView1.DataSource = cartProducts;
        }
        public void SetAccuredPaymentBindingSource(BindingSource accuredPayment)
        {
            dataGridViewAccuredPayment.DataSource = accuredPayment;
        }

        //Singleton Pattern
        private static Form4 instance;
        public static Form4 GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Form4();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void kryptonTextBox1_Click(object sender, EventArgs e)
        {
            phTextBox.Text = "";
        }

        private void rcTextBox_Click(object sender, EventArgs e)
        {
            rcTextBox.Text = "";
        }
    }
}
