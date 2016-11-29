using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonFinancials;
using Xunit;

namespace BangazonFinancialsTests
{
    public class DatabaseGeneratorTests
    {
        [Fact]
        public void TestFileIsWorking()
        {
            bool DGTestsWorks = true;

            Assert.True(DGTestsWorks);
        }

        [Fact]

        public void CanCreateConnectionToDB()
        {
            DatabaseGenerator DBGen = new DatabaseGenerator();

            Assert.NotNull(DBGen);

        }

    }
}