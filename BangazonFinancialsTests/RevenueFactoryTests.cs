using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonFinancials;
using Xunit;

namespace BangazonFinancialsTests
{
    public class RevenueFactoryTests
    {

        [Fact]
        public void RevenueFactoryTestsWorking ()
        {
            bool GreenCheck = true;

            Assert.True(GreenCheck);
        }

        [Fact]
        public void CanCreateRevenueFactory()
        {
            RevenueFactory testRevenueFactory = new RevenueFactory();

            Assert.NotNull(testRevenueFactory);
        }

        [Fact]

        public void CanGetRevenueFromPast7Days()
        {
            RevenueFactory revenueFactory = new RevenueFactory();
            var AllRevenue = revenueFactory.getAllRevenue();
            List<Revenue> RevenueToPrint = new List<Revenue>();
            DateTime EndOfWeek = DateTime.Today.AddDays(-7);

            foreach (var r in AllRevenue)
            {
                if (r.PurchaseDate > EndOfWeek)
                {
                    RevenueToPrint.Add(r);
                }
            }

            foreach (Revenue item in RevenueToPrint)
            {
                Assert.NotNull(item.ProductName);
                Assert.NotNull(item.ProductRevenue);
                Assert.True(item.PurchaseDate > EndOfWeek);
            }
        }


         [Fact]

        public void CanGetRevenueFromPast30Days()
        {
            RevenueFactory revenueFactory = new RevenueFactory();
            var AllRevenue = revenueFactory.getAllRevenue();
            List<Revenue> RevenueToPrint = new List<Revenue>();
            DateTime EndOfMonth = DateTime.Today.AddDays(-30);

            foreach (var r in AllRevenue)
            {
                if (r.PurchaseDate > EndOfMonth)
                {
                    RevenueToPrint.Add(r);
                }
            }

            foreach (Revenue item in RevenueToPrint)
            {
                Assert.NotNull(item.ProductName);
                Assert.NotNull(item.ProductRevenue);
                Assert.True(item.PurchaseDate > EndOfMonth);
            }
        }

        [Fact]

        public void CanGetRevenueFromPast90Days()
        {
            RevenueFactory revenueFactory = new RevenueFactory();
            var AllRevenue = revenueFactory.getAllRevenue();
            List<Revenue> RevenueToPrint = new List<Revenue>();
            DateTime EndOfQuarter = DateTime.Today.AddDays(-90);

            foreach (var r in AllRevenue)
            {
                if (r.PurchaseDate > EndOfQuarter)
                {
                    RevenueToPrint.Add(r);
                }
            }

            foreach (Revenue item in RevenueToPrint)
            {
                Assert.NotNull(item.ProductName);
                Assert.NotNull(item.ProductRevenue);
                Assert.True(item.PurchaseDate > EndOfQuarter);
            }
        }


        [Fact]
        public void CanGetTotalRevenueListedByCustomer()
        {
            RevenueFactory revenueFactory = new RevenueFactory();
            Dictionary<string, int> CustomerRev = revenueFactory.GetRevenueByCustomer();
            Assert.Equal(typeof(Dictionary<string, int>), CustomerRev.GetType());
            Assert.Equal(CustomerRev, revenueFactory.GetRevenueByCustomer());
            Assert.NotNull(CustomerRev);
            Assert.NotEmpty(CustomerRev);
        }

    }
}
