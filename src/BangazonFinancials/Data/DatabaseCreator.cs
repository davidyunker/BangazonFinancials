
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace BangazonFinancials
{


    public class DatabaseSeeding
    {
        private static string _connectionString = "Data Source=" + System.Environment.GetEnvironmentVariable("Bangazon_Db_Path2");
        public static void createTables()
        {
            SqliteConnection dbcon = new SqliteConnection(_connectionString);
            
            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();

            dbcmd.CommandText = @"   CREATE TABLE Revenue
 +                (
 +                    RevenueId integer NOT NULL PRIMARY KEY AUTOINCREMENT,
 +                    ProductName text not null,
 +                    ProductCost integer not null,
 +                    ProductRevenue integer not null,
 +                    ProductSupplierState text not null,
					  CustomerFirstName text not null,
					  CustomerLastName text not null,
					  CustomerAddress text not null,
					  CustomerZipCode integer not null,
					  PurchaseDate datetime not null default (strftime('%Y-%m-%d %H:%M:%S'))

 +                );";
            dbcmd.ExecuteNonQuery();
            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}

//            INSERT INTO Employee
// +                (
// +                FirstName, LastName, DepartmentName, IsAdmin
// +                )
// +                VALUES
// +                (
// +                'Bob', 'Bobson', 'IT', 0
// +                );
// +



//       customers = "Carys", "Emmett", "Latoya", "Trina", "Kade", "Torin", "Aggie", "Caelan", "Patsy", "Bettina", "Hans", "Leda", "Clair", "Evan", "Roscoe", "Sondra", "Dixon", "Gail" };
//        customersLastName = new[] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin" };
//        products = new[] { "Rug", "Wine Glasses", "Book Ends", "Picture Frame", "Blu-Ray Player", "Digital Camera", "Stuffed Animal - Monkey", "Stuffed Animal - Sloth", "Spatula", "Crayons", "Headphones", "Lawn Furniture", "Hammer", "Computer Monitor", "Golf Clubs", "Raspberry Pi", "eReader" };
//        productprice = new[] { 57, 21, 16, 22, 95, 257, 4, 5, 10, 2, 53, 150, 25, 950, 860, 45, 250 };
//        productrevenue = new[] { 3, 1, 4, 2, 15, 52, 1, 1, 1, 1, 5, 53, 3, 24, 169, 10, 9 };
//        customerAddressNumbers = new[] { "123", "435", "44", "283a", "6b", "1440", "7723", "289", "7564", "985-b", "33922", "23", "546", "5692", "6780", "9362", "121", "74567", "18", "9" };
//        customerAddressStreet = new[] { "Mallory Lane", "Carothers Pkwy", "Claybrook Lane", "Bending Creek Drive", "Old Hickory Blvd", "Harris Ave", "21st Ave N", "Plus Park Blvd", "Interstate Blvd S", "Whitney Ave", "Bell Rd", "Harding Pky", "Nolesville Road", "Charlotte Ave" };
//        customerZipcode = new int[] { 37013, 37072, 38461, 37115, 37116, 37201, 37211, 37216, 37222 };
//        supplierState = new string[] { "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HA", "ID", "IL", "IN", "IA", "KA", "KY", "LA", "ME", "MD", "MS", "MC", "MN", "MI", "MO", "MT", "NB", "NV", "NH", "NJ", "NC", "NY", "NM", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "WA", "WV", "WI", "WY" };

//            DateTime start = DateTime.Today.AddDays(-200);
//            int range = (DateTime.Today - start).Days;

//            string command = $@"
//            INSERT INTO Revenue 
//            VALUES (
//                null,
//                '{products[rnd3]}', 
//                {productprice[rnd3]}, 
//                {productrevenue[rnd3]}, 
//                '{supplierState[rnd7]}', 
//                '{customers[rnd1]}', 
//                '{customersLastName[rnd2]}', 
//                '{customerAddressNumbers[rnd4]} {customerAddressStreet[rnd5]}', 
//                {customerZipcode[rnd6]}, 
//                '{start.AddDays(rnd.Next(range))}'
//            );";

//            return command;
//        }






//        }
//    }
//}