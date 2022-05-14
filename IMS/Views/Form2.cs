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
    public partial class Form2 : KryptonForm, ICustomerView
    {
        private bool isEdit;
        private bool isSuccess;
        private string message;
        public Form2()
        {
            InitializeComponent();
            AssociateandRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
            button5.Click += delegate { this.Close(); };
        }

        private void AssociateandRaiseViewEvents()
        {
            button4.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            button7.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };

            button6.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };

            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Other
            //Add
            button1.Click += delegate
            {

                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Add Customer";
            };

            //Edit
            button3.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Edit Customer";
            };

            //Delete 
            button2.Click += delegate
            {
                DeleteEvent?.Invoke(this, EventArgs.Empty);

            };
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public string Id 
        { 
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Name
         { 
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string PhoneNumber
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string Email
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public string Address
        {
            get { return textBox7.Text; }
            set { textBox7.Text = value; }
        }
        public string SearchValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
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


        //Singleton Pattern
        private static Form2 instance;
        public static Form2 GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Form2();
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

        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            dataGridView.DataSource = customerList;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
