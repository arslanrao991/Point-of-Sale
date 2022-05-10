using IMS._Repositories;
using IMS.Models;
using IMS.Presenter;
using IMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

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
            //string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            string sqlConnectionString = "Data Source=DESKTOP-7GFBFE2;Initial Catalog=IMS;Integrated Security=True"; 
            IProductView view = new Form1();
            IProductRepository repo = new ProductRepository(sqlConnectionString);
            new ProductPresenter(view, repo);
            Application.Run((Form)view) ;
        } 
    }
}
