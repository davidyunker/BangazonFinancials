using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonFinancials;
using Xunit;

namespace BangazonFinancialsTests
{
    public class RevenueTest
    {
        Revenue testRevenue = new Revenue
        {
            Id = 1,
            ProductName = "Swiffer",
            ProductCost = 24,
            ProductRevenue = 10,
            ProductSupplierState = "TN",
            CustomerFirstName = "Bob",
            CustomerLastName = "Jones",
            CustomerAddress = "345 Yo Street",
            CustomerZipCode = 37204
        };


        [Fact]
        public void IsRevenueTestWorking()
        {
            bool IsPictureDay = true;

            Assert.True(IsPictureDay);

        }

        [Fact]

        public void RevenueClassWorks()
        {
            Assert.NotNull(testRevenue);

        }

        [Fact]

        public void NoPurchaseDateAssigned()
        {
            Assert.NotNull(testRevenue.PurchaseDate);
        }

        [Fact]

        public void SwifferIsMyProductName()
        {
            Assert.Equal(testRevenue.ProductName, "Swiffer");
        }
    }
}
