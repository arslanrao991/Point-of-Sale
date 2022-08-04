using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IMS.Models
{
    public class ProductDashboardModel
    {
        public string name;
        public int id;
        public int quantity;

        public ProductDashboardModel(int id, string name,  int quantity)
        {
            this.name = name;
            this.id = id;
            this.quantity = quantity;
        }
    }
    public class DashboardModel
    {
        //--------Fields
        private DateTime startDate;
        private DateTime endDate;
        //private int numDays;

        //---------Properties
        [DisplayName("Total Customers")]
        [Required(ErrorMessage = "Total Customers Required")]
        public int numCustomers { get; private set; }

        [DisplayName("Total Products")]
        [Required(ErrorMessage = "Total Products Required")]
        public int numProducts { get; private set; }


        public List<PReportsModel> TopProducts { get; private set; }
        public List<ProductDashboardModel> UnderStockProd { get; private set; }

        [DisplayName("Total Orders")]
        [Required(ErrorMessage = "Total Orders Required")]
        public int NumOrder { get; private set; }

        [DisplayName("Total Revenue ")]
        [Required(ErrorMessage = "Total Revenue  Required")]
        public float TotalRevenue { get; private set; }


    }
}
