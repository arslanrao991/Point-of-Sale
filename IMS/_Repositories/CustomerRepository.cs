using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;


namespace IMS._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private string connectionString;

        public CustomerRepository(string sqlConnectionString)
        {
            this.connectionString = sqlConnectionString;
        }

        public void Add(CustomerModel customer)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("AddCustomerTransaction", connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@c_id", customer.Id);
                command.Parameters.Add("@name", customer.Name);
                command.Parameters.Add("@ph", customer.PhoneNumber);
                command.Parameters.Add("@email", customer.Email);
                command.Parameters.Add("@address", customer.Address);

                command.ExecuteReader();
            }

            
        }

        public void Delete(int customerId)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete from Customer where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = customerId;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<CustomerModel> FindByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var customerList = new List<CustomerModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                var customerModel = new CustomerModel();
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand("GetCutomerRecord", connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataSet ds = new DataSet();
                    da.Fill(ds, "customer");

                    DataTable dt = ds.Tables["customer"];

                    foreach (DataRow row in dt.Rows)
                    {
                        customerModel = new CustomerModel();
                        customerModel.Id = Convert.ToInt32(row["ID"]);
                        customerModel.Name =(string) (row["Customer_Name"]);
                        customerModel.PhoneNumber = (string)row["Customer_Phone_No"];
                        customerModel.Email = (string)row["Customer_Email"];
                        customerModel.Address = (string)row["Customer_Address"];
                        if(!row["Total_Purchases"].ToString().Equals(""))
                            customerModel.TotalPurchases = Convert.ToDouble(row["Total_Purchases"]);
                        if (!row["Balance"].ToString().Equals(""))
                            customerModel.Balance = Convert.ToDouble(row["Balance"]);
                        customerList.Add(customerModel);
                    }
                }
            }
            return customerList;
        }

        public IEnumerable<CustomerModel> GetByValue(string value)
        {
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string name = value;
            string phone = value;

            var customerList = new List<CustomerModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                var customerModel = new CustomerModel();
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand("GetSearchedCutomerRecord", connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    da.SelectCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;

                    DataSet ds = new DataSet();
                    da.Fill(ds, "customer");

                    DataTable dt = ds.Tables["customer"];

                    foreach (DataRow row in dt.Rows)
                    {
                        customerModel = new CustomerModel();
                        customerModel.Id = Convert.ToInt32(row["ID"]);
                        customerModel.Name = (string)(row["Customer_Name"]);
                        customerModel.PhoneNumber = (string)row["Customer_Phone_No"];
                        customerModel.Email = (string)row["Customer_Email"];
                        customerModel.Address = (string)row["Customer_Address"];
                        if (!row["Total_Purchases"].ToString().Equals(""))
                            customerModel.TotalPurchases = Convert.ToDouble(row["Total_Purchases"]);
                        if (!row["Balance"].ToString().Equals(""))
                            customerModel.Balance = Convert.ToDouble(row["Balance"]);
                        customerList.Add(customerModel);
                    }
                }
            }
            return customerList;
        }

        public void Update(CustomerModel customer)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update  Customer set Customer_Name=@name, Customer_Phone_No=@phone_no, Customer_Email=@email, Customer_Address=@address " +
                    "where ID=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = customer.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customer.Name;
                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = customer.PhoneNumber;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customer.Email;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = customer.Address;
                command.ExecuteNonQuery();
            }
        }
    }
}
