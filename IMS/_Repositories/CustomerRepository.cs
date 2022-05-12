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
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into customers values(@C_id, @name, @ph_no, @email, @address);";
                command.Parameters.Add("@C_id", SqlDbType.Int).Value = customer.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customer.Name;
                command.Parameters.Add("@ph_no", SqlDbType.NVarChar).Value =customer.PhoneNumber;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customer.Email;
                command.Parameters.Add("@address", SqlDbType.Int).Value = customer.Address;
                command.ExecuteNonQuery();
            }
            
        }

        public void Delete(int customerId)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete from Customers where id=@id";
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
            var customerlist = new List<CustomerModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select Paid_Bills.ID, Paid_Bills.Customer_Name, Paid_Bills.Customer_Phone_No,Paid_Bills.Customer_Email,Paid_Bills.Customer_Address, Paid_Bills.Total_Purchases  ,(Paid_Bills.Total_Purchases - (Paid_Bills.Paid_Bill+Accured_Payments_Table.Accured_Payment)) as Balance" +
                                      "From (select C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address, SUM(S.Total_Bill) as Total_Purchases, (Sum(S.Paid_Bill)) as Paid_Bill" +
                                      "From Customers as C" +
                                      "join Sales as S on C.ID = S.Customer_ID" +
                                      "Group by C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address) as Paid_Bills join" +
                                      "(select C.ID, SUm(AP.Paid_Price) as Accured_Payment" +
                                      "From Customers as C" +
                                      "join Accured_Payments as AP on C.ID = AP.Customer_ID" +
                                      "Group by C.ID) as Accured_Payments_Table on Paid_Bills.ID = Accured_Payments_Table.ID";
                using (var reader = command.ExecuteReader())
                {
                    var customerModel = new CustomerModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            customerModel = new CustomerModel();
                            customerModel.Id = (int)reader["ID"];
                            customerModel.Name = (string)reader["Customer_Name"].ToString();
                            customerModel.PhoneNumber = (string)reader["Customer_Phone_No"].ToString();
                            customerModel.Email = (string)reader["Customer_Email"].ToString();
                            customerModel.Address = (string)reader["Customer_Address"];
                            customerModel.TotalPurchases = (double)reader["total_Purchases"];
                            customerModel.Balance = (double)reader["balance"];
                            customerlist.Add(customerModel);
                        }
                    }
                    reader.Close();

                }
            }
            return customerlist;
        }

        public IEnumerable<CustomerModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerModel customer)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update  Customers set Customer_Name=@name, Customer_Phone_No=@phone_no, Customer_Email=@email, Customer_Address=@address " +
                    "where ID=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = customer.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customer.Name;
                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = customer.PhoneNumber;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customer.Email;
                command.Parameters.Add("@address", SqlDbType.Int).Value = customer.Address;
                command.ExecuteNonQuery();
            }
        }
    }
}
