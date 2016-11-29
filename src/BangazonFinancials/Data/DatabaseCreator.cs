using System;
using Microsoft.Data.Sqlite;

namespace BangazonFinancials
{
    
    public class DatabaseGenerator
 
    {
        private string _connectionString = $"Data Source = {Environment.GetEnvironmentVariable("Revenue_Bangazon_Db")}";

        public string ConnectionString ()
        {
            return _connectionString;
        }

        Random rnd = new Random();
        DatabaseSeed databaseSeed = new DatabaseSeed();


    
        public void CreateDatabase()
        {
            try
                { 
            SqliteConnection connection = new SqliteConnection(_connectionString);
                connection.Open();
                SqliteCommand dbcmd = connection.CreateCommand();

            string RevenueTable = "CREATE TABLE Revenue (" +
                                "[Id] INTEGER NOT NULL CONSTRAINT \"PK_Revenue\" PRIMARY KEY AUTOINCREMENT, " +
                                "[ProductName] TEXT NOT NULL, " +
                                "[ProductCost] INTEGER NOT NULL," +
                                "[ProductRevenue] INTEGER NOT NULL, " +
                                "[ProductSupplierState] TEXT NOT NULL, " +
                                "[CustomerFirstName] TEXT NOT NULL, " +
                                "[CustomerLastName] TEXT NOT NULL, " +
                                "[CustomerAddress] TEXT NOT NULL, " +
                                "[CustomerZipCode] INTEGER NOT NULL, " +
                                "[PurchaseDate] TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%S')) " +
                            "); "
                            + RandomizeCustomerProducts(1000);
                dbcmd.CommandText = RevenueTable;
                dbcmd.Dispose();
                connection.Close();
                }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex);
            }
        }


        public string RandomizeCustomerProducts()
        {
            var rnd1 = rnd.Next(databaseSeed.customersFirstName.Length);
            var rnd2 = rnd.Next(databaseSeed.customersLastName.Length);
            var rnd3 = rnd.Next(databaseSeed.products.Length);
            var rnd4 = rnd.Next(databaseSeed.customerAddressNumbers.Length);
            var rnd5 = rnd.Next(databaseSeed.customerAddressStreet.Length);
            var rnd6 = rnd.Next(databaseSeed.customerZipcode.Length);
            var rnd7 = rnd.Next(databaseSeed.supplierState.Length);

            DateTime start = DateTime.Today.AddDays(-200);
            int range = (DateTime.Today - start).Days;

            string command = $@"
            INSERT INTO Revenue 
            VALUES (
                null,
                '{databaseSeed.products[rnd3]}', 
                {databaseSeed.productprice[rnd3]}, 
                {databaseSeed.productrevenue[rnd3]}, 
                '{databaseSeed.supplierState[rnd7]}', 
                '{databaseSeed.customersFirstName[rnd1]}', 
                '{databaseSeed.customersLastName[rnd2]}', 
                '{databaseSeed.customerAddressNumbers[rnd4]} {databaseSeed.customerAddressStreet[rnd5]}', 
                {databaseSeed.customerZipcode[rnd6]}, 
                '{start.AddDays(rnd.Next(range))}'
            );";

            return command;
        }

        public string RandomizeCustomerProducts(int numOfEntries)
        {
            string returnstring = "";
            for (var i = 0; i < numOfEntries; i++) { returnstring += RandomizeCustomerProducts(); }
            return returnstring;
        }

        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon = new SqliteConnection(_connectionString);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            dbcmd.Dispose();
            dbcon.Close();
        }


    }
}