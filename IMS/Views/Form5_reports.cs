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
    public partial class Form5_reports : KryptonForm, IReportsView
    {
        private bool isEdit;
        private bool isSuccess;
        private string message;

        public Form5_reports()
        {
            InitializeComponent();
            AssociateandRaiseViewEvents();
            button5.Click += delegate { this.Close(); };
        }

        private void AssociateandRaiseViewEvents()
        {

            button4.Click += delegate
            {
                AddCustEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
                tabPage1.Text = "Customers";
            };

           
            button1.Click += delegate
            { 
            };

            //Edit
            button3.Click += delegate
            {
                AddProdEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Products";
            };

            //Delete 
            button2.Click += delegate
            {
               // DeleteEvent?.Invoke(this, EventArgs.Empty);

            };
        }

        string IReportsView.Id { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }
        string IReportsView.Name { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); 
        }
        string IReportsView.Sales { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }


        public event EventHandler SearchEvent;
        public event EventHandler AddProdEvent;
        public event EventHandler AddCustEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        //Singleton Pattern
        private static Form5_reports instance;
        public static Form5_reports GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Form5_reports();
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

        public void SetReportListBindingSource(BindingSource reportList)
        {
            dataGridView.DataSource = reportList;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        void IReportsView.SetReportListBindingSource(BindingSource reportList)
        {
            throw new NotImplementedException();
        }

        void IReportsView.Show()
        {
            throw new NotImplementedException();
        }
    }
}
