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
    public class DashboardRepository : BaseRepository, IDashboardRepository
    {
        public DashboardRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int GetNumOrders(DateTime startDate, DateTime endDate) //total sales for a time
        {
            int NumItems = 0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select count(*) as numItems from Sales S where S.[Date] between @toDate and @fromDate";
                command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value= startDate;
                command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = endDate;
                using (var reader = command.ExecuteReader())
                {
                    var customerReportModel = new CReportsModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            NumItems = (int)reader["numItems"];
                        }
                    }
                    reader.Close();

                }
            }
            if (NumItems >= 0)
            {
                return NumItems;
            }
            return 0;
        }
        public int GetNumCustomers()        //total num of cust
        {
            int NumItems = 0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select COUNT(*) as numItems from Customer";
                using (var reader = command.ExecuteReader())
                {
                    var customerReportModel = new CReportsModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            NumItems = (int)reader["numItems"];
                        }
                    }
                    reader.Close();

                }
            }
            if (NumItems >= 0)
            {
                return NumItems;
            }
            return 0;
        }
        public int GetNumProducts()//total products in inv
        {
            int NumItems=0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select COUNT(*) as numItems from Products P";
                using (var reader = command.ExecuteReader())
                {
                    var customerReportModel = new CReportsModel();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            NumItems = (int)reader["numItems"];
                        }
                    }
                    reader.Close();

                }
            }
            if (NumItems >= 0)
            {
                return NumItems;
            }
            return 0;
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



        public IEnumerable<int> MonthlySales()
        {
            var MonthlySalesList = new List<int>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 1";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 2";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 3";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 4";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 5";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 6";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 7";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 8";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 9";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 10";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 11";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
                command.CommandText = "select sum(S.Total_Bill)as [MonthlySales] from Sales S where MONTH(S.[Date]) = 12";
                using (var reader = command.ExecuteReader())
                {
                    var temp = new int();
                    if (reader.HasRows)
                    {
                        temp = (int)reader["MonthlySales"];
                        MonthlySalesList.Add(temp);
                    }
                    reader.Close();
                }
            }
            return MonthlySalesList;
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
                            prodReportModel.Sales = Convert.ToDouble(reader["SUM"]);
                            ProductList.Add(prodReportModel);
                        }
                    }
                    reader.Close();

                }
            }
            return ProductList;
        }
        public IEnumerable<ProductDashboardModel> GetLowStock()
        {
            var DashboardList = new List<ProductDashboardModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select P.ID, P.Product_Name, P.Product_Quantity from Products P where P.Product_Quantity<20";
                using (var reader = command.ExecuteReader())
                {
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var currQuantity = new ProductDashboardModel((int)reader["ID"], (string)reader["Product_Name"], (int)reader["Product_Quantity"]);
                        }
                    }
                    reader.Close();

                }
            }
            return DashboardList;
        }
    }

}
