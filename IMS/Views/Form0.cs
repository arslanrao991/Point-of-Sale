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
        }

        public event EventHandler ShowProductView;

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
