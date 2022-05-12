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
        private string sqlConnectionString;

        public SupplierRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
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
                command.Parameters.Add("@address", SqlDbType.Int).Value = supplier.Address;
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
                command.CommandText = "Delete from Suppliers where id=@id";
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
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> GetByValue(string value)
        {
            throw new NotImplementedException();
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
                command.Parameters.Add("@address", SqlDbType.Int).Value = supplier.Address;
                command.ExecuteNonQuery();
            }
        }
    }
}
