using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;




namespace BangazonFinancials
{
    public class Program
    {
        public static void Main(string[] args)
        {

            bool dbIsFullySeeded = false;
            DatabaseGenerator DatabaseGenerator = new DatabaseGenerator();
            string connectionstring = DatabaseGenerator.ConnectionString();
            SqliteCommand sqliteCommand = new SqliteCommand();
            sqliteCommand.Connection = new SqliteConnection(connectionstring);
            string Banner = "==========================";
            string Greeting = "BANGAZON FINANCIAL REPORTS";

            //Greet the user and prompt to enter name or create account and capture user input

            Console.WriteLine(Banner + "\r\n" + Greeting + "\r\n" + Banner);


            try
            {
                DatabaseGenerator.execute(@"
            SELECT Id
            FROM REVENUE
            WHERE Id = 1000", (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        dbIsFullySeeded = true;
                    }
                });
                // Console.WriteLine("database has already been seeded");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                DatabaseGenerator.CreateDatabase();
                Console.WriteLine("Database has been seeded");

            }


            DateTime EndOfWeek = DateTime.Today.AddDays(-7);
            DateTime EndOfMonth = DateTime.Today.AddDays(-30);
            DateTime EndOfQuarter = DateTime.Today.AddDays(-90);
            RevenueFactory revenueFactory = new RevenueFactory();
            var AllRevenue = revenueFactory.getAllRevenue();
            var RevenueByCustomer = revenueFactory.GetRevenueByCustomer();
            List<Revenue> RevenueToPrint = new List<Revenue>();

            bool go_on = true;

            while (go_on)
            {
                try
                {

                    Console.WriteLine("1 - Last Week Report");
                    Console.WriteLine("2 - Last Month Report");
                    Console.WriteLine("3 - Last 3 months Report");
                    Console.WriteLine("4 - Revenue by customer");
                    Console.WriteLine("5 - Revenue by product");

                    var menuAction = Console.ReadLine();
                    Console.WriteLine(menuAction);

                    switch (menuAction)
                    {
                        case "1":
                            foreach (var r in AllRevenue)
                            {
                                if (r.PurchaseDate > EndOfWeek)
                                {
                                    RevenueToPrint.Add(r);
                                }
                            }

                                foreach (var r in RevenueToPrint)
                                {
                                    Console.WriteLine(string.Format("WEEKLY REPORT: Product: {0} Revenue: ${1}.00 ", r.ProductName, r.ProductCost));
                                }
                                break;
                        case "2":
                            foreach (var r in AllRevenue)
                            {
                                if (r.PurchaseDate > EndOfMonth)
                                {
                                    RevenueToPrint.Add(r);
                                }
                            }

                            foreach (var r in RevenueToPrint)
                            {
                                Console.WriteLine(string.Format("MONTHLY REPORT: Product: {0} Revenue: ${1}.00 ", r.ProductName, r.ProductCost));
                            }
                            break;
                        case "3":
                            foreach (var r in AllRevenue)
                            {
                                if (r.PurchaseDate > EndOfQuarter)
                                {
                                    RevenueToPrint.Add(r);
                                }
                            }

                            foreach (var r in RevenueToPrint)
                            {
                                Console.WriteLine(string.Format("QUARTERLY REPORT: Product: {0} Revenue: ${1}.00 ", r.ProductName, r.ProductCost));
                            }

                            break;
                        case "4":
                           
                                foreach (KeyValuePair<string, int> r in RevenueByCustomer)
                                {
                                    Console.WriteLine(string.Format("Customer Name: {0}  Customer Revenue: ${1}.00", r.Key, r.Value));
                                }
                                break;
                           
                        case "5":
            
                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    //ADDING ERROR HANDLING
                    Console.WriteLine("Sorry an error has occcured. Please try agin ");
                    Console.WriteLine($"{ex}");
                    go_on = false;
                    Console.ReadKey();
                }

            }
        }
    }
}




