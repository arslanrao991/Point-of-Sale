using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Views
{
    public partial class Form1 : Form, IProductView
    {
        private string productId;
        private string productName;
        private string productDescription;
        private string productCategory;
        private int productQuantity;
        private double per_unit_price;

        private string searchValue;
        private bool isEdit;
        private bool issuccess;
        private string message;
        private DataGridView dataGridView = new DataGridView();

        public Form1()
        {
            InitializeComponent();
            AssociateandRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void AssociateandRaiseViewEvents()
        {
            button4.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SearchValue { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccessful 
        {
            get { return IsSuccessful; }
            set { IsSuccessful = value; }
        }
        public string Message 
        { 
            get { return message; }
            set { message = value; }
        }
        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetProductListBindingSource(BindingSource productList)
        {
            dataGridView.DataSource = productList;
        }
    }
}
