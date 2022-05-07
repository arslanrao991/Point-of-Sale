using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IMS.Models
{
    public class ProductsModel
    {
        //Fields
        private int id;
        private string name;
        private string description;
        private string category;
        private int quantity;
        private double per_unit_price;

        //Properties - Validations

        [DisplayName("Product ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName ("Name")]
        [Required (ErrorMessage="Product name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage="Product name must be between 3 and 50 characters")]
        public string Name { get => name; set => name = value; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Product description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product description must be between 3 and 50 characters")]
        public string Description { get => description; set => description = value; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Specify Product Category")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category length must be between 3 and 50 characters")]
        public string Category { get => category; set => category = value; }
        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity not mentioned")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Quantity not mentioned")]
        public int Quantity { get => quantity; set => quantity = value; }
        [DisplayName("Per Unit Price")]
        [Required(ErrorMessage = "Per Unit Price not mentioned")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Provide per unit price")]
        public double PerUnitPrice { get => per_unit_price; set => per_unit_price = value; }
    }
}
