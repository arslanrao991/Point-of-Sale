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
    internal class SalesRepository: BaseRepository, ISalesRepository
    {
        private string connectionString;

        public SalesRepository(string sqlConnectionString)
        {
            this.connectionString = sqlConnectionString;
        }

        public void Add(SalesProductModel sales)
        {
            throw new NotImplementedException();
        }

        public void Delete(int salesId)
        {
            throw new NotImplementedException();
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
                            salesModel.Id = (int)reader["ID"];
                            salesModel.ProductId = (int)reader["Product_ID"];
                            salesModel.CusotmerID = (int)reader["Customer_ID"];
                            salesModel.Quantity = (int)reader["Product_Quantity"];
                            salesModel.Price = (double)reader["Product_Per_Unit_Price"];
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
            throw new NotImplementedException();
        }

        public void Update(SalesModel sales)
        {
            
        }
    }
}
