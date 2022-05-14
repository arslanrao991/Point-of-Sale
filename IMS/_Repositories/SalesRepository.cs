using IMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS._Repositories
{
    internal class SalesRepository : BaseRepository, ISalesRepository
    {
        private string connectionString;

        public SalesRepository(string sqlConnectionString)
        {
            this.connectionString = sqlConnectionString;
        }

        public int ProcessSale(DataTable sale, string phone, double total_bill, double received_amounts)
        {
            var customerList = new List<CustomerModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("ProcessSalesTransaction", connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cart", sale);
                command.Parameters.Add("@products_count", sale);
                command.Parameters.Add("@phone", sale);
                command.Parameters.Add("@total", total_bill);
                command.Parameters.Add("@paid", received_amounts);


                command.ExecuteReader();
            }

            return 1;
        }


        public IEnumerable<SalesModel> FindByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesModel> GetAll()
        {
            var salesList = new List<SalesModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                    
                command.CommandText = "SELECT SalesDetails.*, Sales.Customer_ID FROM SalesDetails join Sales on SalesDetails.Sales_ID=Sales.Sales_ID ORDER BY Sales_ID DESC";
                using (var reader = command.ExecuteReader())
                {
                    var salesModel = new SalesModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            salesModel = new SalesModel();
                            salesModel.Id = (int)reader["Sales_ID"];
                            salesModel.ProductId = (int)reader["Product_ID"];
                            salesModel.CusotmerID = (int)reader["Customer_ID"];
                            salesModel.Quantity = (int)reader["Quantity"];
                            salesModel.Price = (double)reader["Per_Unit_Price"];
                            salesList.Add(salesModel);
                        }
                    }
                    reader.Close();

                }
            }
            return salesList;
        }

        public IEnumerable<SalesModel> GetByValue(string value)
        {
            int sales_id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int product_id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int customer_id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            var salesList = new List<SalesModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;


                command.CommandText = "SELECT SalesDetails.*, Sales.Customer_ID FROM SalesDetails join Sales on SalesDetails.Sales_ID=Sales.Sales_ID where Sales.Sales_ID=@sales_id or Product_ID=@product_id or Customer_ID=@customer_id ORDER BY Sales_ID DESC";
                command.Parameters.Add("@sales_id", SqlDbType.Int).Value = sales_id;
                command.Parameters.Add("@product_id", SqlDbType.Int).Value = product_id;
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = customer_id;

                using (var reader = command.ExecuteReader())
                {
                    var salesModel = new SalesModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            salesModel = new SalesModel();
                            salesModel.Id = (int)reader["Sales_ID"];
                            salesModel.ProductId = (int)reader["Product_ID"];
                            salesModel.CusotmerID = (int)reader["Customer_ID"];
                            salesModel.Quantity = (int)reader["Quantity"];
                            salesModel.Price = (double)reader["Per_Unit_Price"];
                            salesList.Add(salesModel);
                        }
                    }
                    reader.Close();

                }
            }
            return salesList;
        }

        public void ReturnSale(int salesId, int product_id, int quantity, int is_bill_paid)
        {
            throw new NotImplementedException();
        }

        public void Update(SalesModel sales)
        {
            
        }
    }
}
