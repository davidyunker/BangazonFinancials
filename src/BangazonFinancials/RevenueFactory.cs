using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace BangazonFinancials
{
    public class RevenueFactory
    {
        DatabaseGenerator DatabaseGenerator = new DatabaseGenerator();

        public List<Revenue> getAllRevenue()
        {
            List<Revenue> AllRevenue = new List<Revenue>();


            DatabaseGenerator.execute(@"SELECT * FROM Revenue
            order by Revenue.ProductName",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            AllRevenue.Add(new Revenue
                            {
                                ProductName = reader[1].ToString(),
                                ProductCost = reader.GetInt32(2),
                                ProductRevenue = reader.GetInt32(3),
                                ProductSupplierState = reader[4].ToString(),
                                CustomerFirstName = reader[5].ToString(),
                                CustomerLastName = reader[6].ToString(),
                                CustomerAddress = reader[7].ToString(),
                                CustomerZipCode = reader.GetInt32(8),
                                PurchaseDate = reader.GetDateTime(9)
                            });
                        }
                    });
            return AllRevenue;
        }


        public Dictionary<string, int> GetRevenueByCustomer()
        {

            Dictionary<string, int> RevenueByCustomer = new Dictionary<string, int>();
            DatabaseGenerator.execute(@"SELECT 
            Revenue.CustomerFirstName,
            Revenue.CustomerLastName,
            SUM(Revenue.ProductRevenue) 
            FROM Revenue
            GROUP BY Revenue.CustomerFirstName
            ORDER BY SUM(Revenue.ProductRevenue) desc",

                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            RevenueByCustomer.Add(reader[0].ToString() + " " + reader[1].ToString(), reader.GetInt32(2));
                        }
                    });
            return RevenueByCustomer;
        }
    }  
}
