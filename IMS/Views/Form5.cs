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
    public partial class Form5 : Form
    {
        public Form5()
        {
            AssociateandRaiseViewEvents();
            button5.Click += delegate { this.Close(); };
        }
        private void AssociateandRaiseViewEvents()
        {
            button1.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };

        }
        public event EventHandler AddNewEvent;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Singleton Pattern
        private static Form5 instance;
        public static Form5 GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Form5();
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
    }
}
