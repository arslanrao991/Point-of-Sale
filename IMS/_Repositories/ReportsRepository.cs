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
    public class ReportsRepository : BaseRepository, IReportsRepository
    {
        public ReportsRepository(string connectionString)
        {
            Console.Write("ReportsRepo Created... ");
            this.connectionString = connectionString;
        }
        public IEnumerable<CReportsModel> GetCustomerList()
        {
            var CustomerList = new List<CReportsModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select Top 5(C.ID), C.Customer_Name, sum(S.Total_Bill) as [SUM] from Sales as S inner join Customer as C on S.Customer_ID = C.ID group by C.ID, C.Customer_Name order by[SUM]";
                using (var reader = command.ExecuteReader())
                {
                    var customerReportModel = new CReportsModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            customerReportModel = new CReportsModel();
                            customerReportModel.Id = (int)reader["ID"];
                            customerReportModel.Name = (string)reader["Customer_Name"].ToString();
                            customerReportModel.Sales = (double)reader["SUM"];
                            CustomerList.Add(customerReportModel);
                        }
                    }
                    reader.Close();

                }
            }
            return CustomerList;
        }

        public IEnumerable<PReportsModel> GetProductList()
        {
            var ProductList = new List<PReportsModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select Top 5(P.ID), P.Product_Name, sum(S.Total_Bill) as [SUM] from Sales as S  inner join SalesDetails as SD on S.Sales_ID = SD.Sales_ID inner join Products as P on P.ID = SD.Product_ID group by P.ID, P.Product_Name order by[SUM]";
                using (var reader = command.ExecuteReader())
                {
                    var prodReportModel = new PReportsModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            prodReportModel = new PReportsModel();
                            prodReportModel.Id = (int)reader["ID"];
                            prodReportModel.Name = (string)reader["Product_Name"].ToString();
                            prodReportModel.Sales = Convert.ToDouble (reader["SUM"]);
                            ProductList.Add(prodReportModel);
                        }
                    }
                    reader.Close();

                }
            }
            return ProductList;
        }

    }
}
