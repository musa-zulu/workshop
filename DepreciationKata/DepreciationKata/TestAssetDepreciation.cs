using System;
using NUnit.Framework;

namespace DepreciationKata
{
    [TestFixture]
    public class TestAssetDepreciation
    {
        [Test]
        public void CalculateDepreciationExpense_GivenStartFinancialYearAs2013AndEndFinancialYearAs2014_ShouldReturn12()
        {
            //---------------Set up test pack-------------------
            var startFinancialYear = new DateTime(2013, 03, 1);
            var endFinancialYear = new DateTime(2014, 02, 28);
            const int expected = 12;
            var depreciation = new AssetDepreciation();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = depreciation.CalculateEconomicLife(startFinancialYear, endFinancialYear);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateDepreciationExpense_GivenStartFinancialYearAs2016AndEndFinancialYearAs2017_ShouldReturn12()
        {
            var startFinancialYear = new DateTime(2016, 03, 1);
            var endFinancialYear = new DateTime(2017, 02, 28);
            const int expected = 12;
            var depreciation = new AssetDepreciation();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = depreciation.CalculateEconomicLife(startFinancialYear, endFinancialYear);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateDepreciationExpense_GivenStartFinancialYearAndEndFinancialYear_ShouldReturnUsefulLifeInYears()
        {
            var startFinancialYear = new DateTime(2013, 03, 1);
            var endFinancialYear = new DateTime(2014, 02, 28);
            const int expected = 12;
            var depreciation = new AssetDepreciation();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = depreciation.CalculateEconomicLife(startFinancialYear, endFinancialYear);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateMonthlyDepreciationCharge_GivenCostAs2000AndResiduaValueAs500_ShouldReturn125()
        {
            //---------------Set up test pack-------------------
            var startFinancialYear = new DateTime(2013, 03, 1);
            var endFinancialYear = new DateTime(2014, 02, 28);
            const double acquisitionCost = 2000;
            const double residualCost = 500;
            const double expected = 125;
            var depreciation = new AssetDepreciation();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = depreciation.CalculateMonthlyDepreciationCharge(startFinancialYear, endFinancialYear, acquisitionCost, residualCost);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateMonthlyDepreciationCharge_GivenCostAs2000AndResiduaValueAs_ShouldReturn166Dot66()
        {
            //---------------Set up test pack-------------------
            var startFinancialYear = new DateTime(2013, 03, 1);
            var endFinancialYear = new DateTime(2014, 02, 28);
            const double acquisitionCost = 2000;
            const double residualCost = 0;
            const double expected = 166.66666666666666d;
            var depreciation = new AssetDepreciation();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = depreciation.CalculateMonthlyDepreciationCharge(startFinancialYear, endFinancialYear, acquisitionCost, residualCost);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateMonthlyDepreciationCharge_GivenCostAndResiduaValueAndEconomicLife_ShouldReturnMonthlyDepreciation()
        {
            //---------------Set up test pack-------------------
            var startFinancialYear = new DateTime(2013, 03, 1);
            var endFinancialYear = new DateTime(2014, 02, 28);
            const double acquisitionCost = 2000;
            const double residualCost = 500;
            const double expected = 125.0d;
            var depreciation = new AssetDepreciation();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = depreciation.CalculateMonthlyDepreciationCharge(startFinancialYear, endFinancialYear, acquisitionCost, residualCost);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

    }
}
