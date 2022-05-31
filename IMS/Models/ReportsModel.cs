using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IMS.Models
{
    public class PReportsModel
    {
        //Fields
        private int id;
        private string name;
        private double sales;

        //Properties 
        [DisplayName("Product ID")]
        [Required(ErrorMessage = "Product name is required")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Product name must be between 1 and 50 characters")]
        public string Name { get => name; set => name = value; }

        [DisplayName("Sales")]
        [Required(ErrorMessage = "Sales not mentioned")]
        public double Sales { get => sales; set => sales = value; }


    }
    public class CReportsModel
    {
        private int id;
        private string name;
        private double sales;
        //Properties 
        [DisplayName("Product ID")]
        [Required(ErrorMessage = "Product name is required")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Product name must be between 1 and 50 characters")]
        public string Name { get => name; set => name = value; }

        [DisplayName("Sales")]
        [Required(ErrorMessage = "Sales not mentioned")]
        public double Sales { get => sales; set => sales = value; }
    }
}
