using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class SupplierModel
    {
        private int id;
        private string name;
        private string phoneNumber;
        private string email;
        private string address;


        [DisplayName("Supplier ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Supplier name must be between 3 and 50 characters")]
        public string Name { get => name; set => name = value; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Supplier phone number is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Supplier phone number must be between 11 and 15 characters")]
        public string PhoneNumber
        {
            get => phoneNumber; set => phoneNumber = value;
        }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
    }
}
