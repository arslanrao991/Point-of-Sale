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


            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Products values(@id, @name, @description, @category, @quantity, @price);";
                command.Parameters.Add("@id", SqlDbType.Int).Value = product.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.Name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = product.Description;
                command.Parameters.Add("@category", SqlDbType.NVarChar).Value = product.Category;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = product.Quantity;
                command.Parameters.Add("@price", SqlDbType.Float).Value = product.PerUnitPrice;
                command.ExecuteNonQuery();
            }

        }

        public void Delete(int productId)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete from Products where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = productId;
                command.ExecuteNonQuery();
            }
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
                        
                        while (reader.Read())
                        {
                            productModel = new ProductsModel();
                            productModel.Id = (int)reader["ID"];
                            productModel.Name = (string)reader["Product_Name"].ToString();
                            productModel.Category = (string)reader["Product_Category"].ToString();
                            productModel.Description = (string)reader["Product_Description"].ToString();
                            productModel.Quantity = (int)reader["Product_Quantity"];
                            productModel.PerUnitPrice = (double)reader["Product_Per_Unit_Price"];
                            productList.Add(productModel);
                        }
                    }
                    reader.Close();
                    
                }
            }
            return productList;
        }

        public IEnumerable<ProductsModel> GetByValue(string value)
        {
            var productList = new List<ProductsModel>();
            int productID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string productName = value;
            string category = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT* FROM Products " +
                                      "WHERE ID=@id or Product_Name like @productName+'%' or Product_Category like @category+'%' " +
                                      "ORDER BY ID DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = productID;
                command.Parameters.Add("@productName", SqlDbType.NVarChar).Value = productName;
                command.Parameters.Add("@category", SqlDbType.NVarChar).Value = category;
                using (var reader = command.ExecuteReader())
                {
                    var productModel = new ProductsModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            productModel = new ProductsModel();
                            productModel.Id = (int)reader["ID"];
                            productModel.Name = (string)reader["Product_Name"].ToString();
                            productModel.Category = (string)reader["Product_Category"].ToString();
                            productModel.Description = (string)reader["Product_Description"].ToString();
                            productModel.Quantity = (int)reader["Product_Quantity"];
                            productModel.PerUnitPrice = (double)reader["Product_Per_Unit_Price"];
                            productList.Add(productModel);
                        }
                    }
                    reader.Close();
                }
            }

            return productList;
        }
       
        public void Update(ProductsModel product)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update  Products set Product_Name=@name, Product_Description=@description, Product_Category=@category, Product_Quantity=@quantity, Product_Per_Unit_Price=@price " +
                    "where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = product.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.Name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = product.Description;
                command.Parameters.Add("@category", SqlDbType.NVarChar).Value = product.Category;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = product.Quantity;
                command.Parameters.Add("@price", SqlDbType.Float).Value = product.PerUnitPrice;
                command.ExecuteNonQuery();
            }
        }
    }
}
