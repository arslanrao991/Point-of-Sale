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
    public partial class Form0 : Form, IMainView
    {
        public Form0()
        {
            InitializeComponent();
            button1.Click += delegate { ShowProductView?.Invoke(this, EventArgs.Empty); };
            button3.Click += delegate { ShowCustomerView?.Invoke(this, EventArgs.Empty); };
            button4.Click += delegate { ShowSupplierView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowProductView;
        public event EventHandler ShowSupplierView;
        public event EventHandler ShowCustomerView;

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
