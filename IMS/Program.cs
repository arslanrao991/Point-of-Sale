using IMS._Repositories;
using IMS.Models;
using IMS.Presenter;
using IMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = "";
            //IProductView view = new Form1();
            //IProductRepository repo = new ProductRepository(sqlConnectionString);
            //new ProductPresenter(view, repo);
            Application.Run(new Form1());
        }
    }
}
