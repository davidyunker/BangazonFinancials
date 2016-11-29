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
            var RevenueByProduct = revenueFactory.GetRevenueByProduct();

            List<Revenue> RevenueToPrint = new List<Revenue>();

            bool go_on = true;

            while (go_on)
            {
                try
                {
                    Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================
1. Weekly Report
2. Monthly Report
3. Quarterly Report
4. Customer Revenue Report
5. Product Revenue Report
x. Exit Program");

                    var menuAction = Console.ReadLine();

                    if (menuAction.ToUpper() == "X")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }



                    switch (menuAction)
                    {
                        case "1":
                            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================
WEEKLY REPORT
Product                                          Amount
-------------------------------------------------------");
                                foreach (var r in AllRevenue)
                                {
                                    if (r.PurchaseDate > EndOfWeek)
                                    {
                                        RevenueToPrint.Add(r);
                                    }
                                }


                             foreach (var r in RevenueToPrint)
                                {

                                Console.WriteLine("{0,-25}{1,30}",
                                r.ProductName,
                                r.ProductCost);    
                                }
                            break;

                        case "2":

                            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================
MONTHLY REPORT
Product                                          Amount
-------------------------------------------------------");
                            foreach (var r in AllRevenue)
                            {
                                if (r.PurchaseDate > EndOfMonth)
                                {
                                    RevenueToPrint.Add(r);
                                }
                            }

                            foreach (var r in RevenueToPrint)
                            {
                                Console.WriteLine("{0,-25}{1,30}",
                               r.ProductName,
                               r.ProductCost
                               );
                            }
                    
                            break;
                        case "3":
                            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================
QUARTERLY REPORT
Product                                          Amount
-------------------------------------------------------");
                            foreach (var r in AllRevenue)
                            {
                                if (r.PurchaseDate > EndOfQuarter)
                                {
                                    RevenueToPrint.Add(r);
                                }
                            }

                            foreach (var r in RevenueToPrint)
                            {
                                Console.WriteLine("{0,-25}{1,30}",
                              r.ProductName,
                              r.ProductCost
                              );
                            }

                            break;
                        case "4":
                            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================
Customer REVENUE REPORT
Customer                                          Amount
-------------------------------------------------------");

                            foreach (KeyValuePair<string, int> r in RevenueByCustomer)
                                {
                                    Console.WriteLine(string.Format("{0, -25} {1, 30}", r.Key, r.Value));
                                }
                                break;
                           
                        case "5":
                            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================
PRODUCT REVENUE REPORT
Product                                          Amount
-------------------------------------------------------");
                            foreach (KeyValuePair<string, int> r in RevenueByProduct)
                            {
                                Console.WriteLine(string.Format("{0, -25}  {1, 30}", r.Key, r.Value));
                            }

                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    //ADDING ERROR HANDLING
                    Console.WriteLine("Sorry an error has occcured. Please try again ");
                    Console.WriteLine($"{ex}");
                    go_on = false;
                    Console.ReadKey();
                }

            }
        }
    }
}




