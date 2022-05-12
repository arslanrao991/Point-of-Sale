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
        private string sqlConnectionString;

        public CustomerRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
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
            throw new NotImplementedException();
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
