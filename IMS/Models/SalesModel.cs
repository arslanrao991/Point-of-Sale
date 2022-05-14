using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class SalesModel
    {
        private int id;
        private int product_id;
        private int customr_id;
        private int quantity;
        private double price;

        [DisplayName("Sales ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Product ID")]
        public int ProductId { get => product_id; set => product_id = value; }

        [DisplayName("Customer ID")]
        public int CusotmerID { get => customr_id; set => customr_id = value; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product quantity is required")]
        public int Quantity { get => quantity; set => quantity = value; }

        [DisplayName("Price Per Unit")]
        [Required(ErrorMessage = "Product price is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product price required")]
        public double Price { get => price; set => price = value; }
    }
}
