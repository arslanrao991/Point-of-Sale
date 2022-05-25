using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class AccuredPaymentsModel
    {
        private int id;
        private int customr_id;
        private string name;
        private string phone;
        private double price;

        [DisplayName("Receipt ID")]
        public int Id { get => id; set => id = value; }


        [DisplayName("Customer ID")]
        public int CusotmerID { get => customr_id; set => customr_id = value; }

        [DisplayName("Customer Name")]
        public string Name { get => name; set => name = value; }

        [DisplayName("Customer Phone")]
        public string Phone { get => phone; set => phone = value; }


        [DisplayName("Payment")]
        public double Price { get => price; set => price = value; }



    }
}
