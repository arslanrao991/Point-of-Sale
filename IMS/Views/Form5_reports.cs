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
using iText;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using IMS.Models;

namespace IMS.Views
{
    public partial class Form5_reports : KryptonForm, IReportsView
    {
        private bool isEdit;
        private bool isSuccess;
        private string message;


        public IEnumerable<CReportsModel> customerList;
        public IEnumerable<PReportsModel> productList;
        public Form5_reports()
        {
            customerList = null;
            InitializeComponent();
            AssociateandRaiseViewEvents();
            //tabControl1.TabPages.Remove(tabPage2);
            //tabControl1.TabPages.Add(tabPage1);
            button5.Click += delegate { this.Close(); };
        }

        private void AssociateandRaiseViewEvents()
        {

            button4.Click += delegate
            {
                AddCustEvent?.Invoke(this, EventArgs.Empty);
                //tabControl1.TabPages.Remove(tabPage2);
                //tabControl1.TabPages.Add(tabPage1);
                //tabPage1.Text = "Customers";
            };

           
            button1.Click += delegate
            {
                AddCustEvent?.Invoke(this, EventArgs.Empty);
                string path = "E:/Customers.pdf";
                PdfWriter writer = new PdfWriter(path);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                document.Add(new Paragraph("IMS: Customer Report\n\n"));
                for (int i=0; i<customerList.Count(); ++i)
                {
                    document.Add(new Paragraph(Convert.ToString(customerList.ElementAt(i).Id) +"\t"+ Convert.ToString(customerList.ElementAt(i).Name) +"\t" +Convert.ToString(customerList.ElementAt(i).Sales)));

                }


                document.Close();

            };

            //Edit
            button3.Click += delegate
            {
                AddProdEvent?.Invoke(this, EventArgs.Empty);
                //tabControl1.TabPages.Remove(tabPage1);
                //tabControl1.TabPages.Add(tabPage2);
                //tabPage2.Text = "Products";
            };

            //Delete 
            button2.Click += delegate
            {
                AddProdEvent?.Invoke(this, EventArgs.Empty);
                string path = "E:/Products.pdf";
                PdfWriter writer = new PdfWriter(path);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                document.Add(new Paragraph("IMS: Products Report\n\n"));
                for (int i = 0; i < productList.Count(); ++i)
                {
                    document.Add(new Paragraph(Convert.ToString(productList.ElementAt(i).Id) + "\t" + Convert.ToString(productList.ElementAt(i).Name) + "\t" + Convert.ToString(productList.ElementAt(i).Sales)));

                }
                document.Close();


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
        void setCustListPDF(IEnumerable<CReportsModel> customerList)
        {
            this.customerList = customerList;
        }
        void IReportsView.SetCReportListBindingSource(BindingSource reportList)
        {
            kryptonDataGridView1.DataSource = reportList;

        }
        void IReportsView.SetPReportListBindingSource(BindingSource reportList)
        {
            kryptonDataGridView2.DataSource = reportList;

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void IReportsView.setProdListPDF(IEnumerable<PReportsModel> productList)
        {
            this.productList = productList;
        }

        void IReportsView.setCustListPDF(IEnumerable<CReportsModel> customerList)
        {
            this.customerList = customerList;
        }
    }
}
