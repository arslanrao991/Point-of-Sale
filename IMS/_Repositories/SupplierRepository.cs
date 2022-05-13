using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;
using System.Data.SqlClient;
using System.Data;

namespace IMS._Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        private string connectionString;

        public SupplierRepository(string sqlConnectionString)
        {
            this.connectionString = sqlConnectionString;
        }

        public void Add(SupplierModel supplier)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Supplier values(@id, @name, @ph_no, @email, @address);";
                command.Parameters.Add("@id", SqlDbType.Int).Value = supplier.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = supplier.Name;
                command.Parameters.Add("@ph_no", SqlDbType.NVarChar).Value = supplier.PhoneNumber;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = supplier.Email;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = supplier.Address;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int supplierId)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete from Supplier where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = supplierId;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SupplierModel> FindByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> GetAll()
        {
            var supplierList = new List<SupplierModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT* FROM Supplier ORDER BY ID DESC";
                using (var reader = command.ExecuteReader())
                {
                    var supplierModel = new SupplierModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            supplierModel = new SupplierModel();
                            supplierModel.Id = (int)reader["ID"];
                            supplierModel.Name = (string)reader["Supplier_Name"].ToString();
                            supplierModel.PhoneNumber = (string)reader["Supplier_Phone_No"].ToString();
                            supplierModel.Email = (string)reader["Supplier_Email"].ToString();
                            supplierModel.Address = (string)reader["Supplier_Address"];
                            supplierList.Add(supplierModel);
                        }
                    }
                    reader.Close();

                }
            }
            return supplierList;
        }

        public IEnumerable<SupplierModel> GetByValue(string value)
        {
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string name = value;
            string phone = value;
            var supplierList = new List<SupplierModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT* FROM Supplier where id=@id or Supplier_Name like @name+'%' or Supplier_Phone_No like @phone+'%' ORDER BY ID DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;

                using (var reader = command.ExecuteReader())
                {
                    var supplierModel = new SupplierModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            supplierModel = new SupplierModel();
                            supplierModel.Id = (int)reader["ID"];
                            supplierModel.Name = (string)reader["Supplier_Name"].ToString();
                            supplierModel.PhoneNumber = (string)reader["Supplier_Phone_No"].ToString();
                            supplierModel.Email = (string)reader["Supplier_Email"].ToString();
                            supplierModel.Address = (string)reader["Supplier_Address"];
                            supplierList.Add(supplierModel);
                        }
                    }
                    reader.Close();

                }
            }
            return supplierList;
        }

        public void Update(SupplierModel supplier)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update  Supplier set Supplier_Name=@name, Supplier_Phone_No=@phone_no, Supplier_Email=@email, Supplier_Address=@address " +
                    "where ID=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = supplier.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = supplier.Name;
                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = supplier.PhoneNumber;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = supplier.Email;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = supplier.Address;
                command.ExecuteNonQuery();
            }
        }
    }
}
