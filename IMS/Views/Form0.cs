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
    public partial class Form0 : KryptonForm, IMainView
    {
        public Form0()
        {
            InitializeComponent();
            button1.Click += delegate { ShowProductView?.Invoke(this, EventArgs.Empty); };
            button3.Click += delegate { ShowCustomerView?.Invoke(this, EventArgs.Empty); };
            button4.Click += delegate { ShowSupplierView?.Invoke(this, EventArgs.Empty); };
            button2.Click += delegate { ShowSalesView?.Invoke(this, EventArgs.Empty); };
            button5.Click += delegate { ShowReportsView?.Invoke(this, EventArgs.Empty); };

        }

        public event EventHandler ShowProductView;
        public event EventHandler ShowSupplierView;
        public event EventHandler ShowCustomerView;
        public event EventHandler ShowSalesView;
        public event EventHandler ShowReportsView;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void Form0_Load_1(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient)
                {

                    control.BackColor = Color.DarkGray;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
