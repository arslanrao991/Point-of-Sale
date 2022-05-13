using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class SalesProductModel
    {
        private int id;
        private int quantity;
        private double price;

        [DisplayName("Product ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product quantity is required")]
        public int Name { get => quantity; set => quantity = value; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Product price is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product price required")]
        public double Description { get => price; set => price = value; }
    }
}
