using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using IMS.Models;

namespace IMS._Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;  
        }
        public void Add(ProductsModel product)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductsModel product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsModel> FindByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsModel> GetAll()
        {
            var productList = new List<ProductsModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT* FROM Products ORDER BY ID DESC";
                using (var reader = command.ExecuteReader())
                {
                    var productModel = new ProductsModel();
                    if (reader.HasRows)
                    {
                        if(reader.Read())
                            productModel.Id = (int)reader[0];
                        productModel.Name = (string)reader["Name"].ToString();
                        productModel.Category = (string)reader["Category"].ToString();
                        productModel.Description = (string)reader["Description"].ToString();
                        productModel.Quantity = (int)reader["Quantity"];
                        productModel.PerUnitPrice = (int)reader["Product_Per_Unit_Price"];
                    }
                    productList.Add(productModel);
                }
            }

            return productList;

        }

        public IEnumerable<ProductsModel> GetByValue(string value)
        {
            var productList = new List<ProductsModel>();
            int productID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string productName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT* FROM Products " +
                                      "WHERE ID=@id or Product_Name like @productName+'%' " +
                                      "ORDER BY ID DEC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = productID;
                command.Parameters.Add("@productName", SqlDbType.NVarChar).Value = productName;
                using (var reader = command.ExecuteReader())
                {
                    var productModel = new ProductsModel();
                    productModel.Id = (int)reader["ID"];
                    productModel.Name = (string)reader["Name"].ToString();
                    productModel.Category = (string)reader["Category"].ToString();
                    productModel.Description = (string)reader["Description"].ToString();
                    productList.Add(productModel);
                }
            }

            return productList;
        }

        public void Update(ProductsModel product)
        {
            throw new NotImplementedException();
        }
    }
}
