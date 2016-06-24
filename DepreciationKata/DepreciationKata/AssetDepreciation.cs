using System;

namespace DepreciationKata
{
    public class AssetDepreciation
    {
        public double CalculateEconomicLife(DateTime startFinancialYear, DateTime endFinancialYear)
        {
            var usefulLifeYears = endFinancialYear.Year - startFinancialYear.Year;
            var ecconomicLife = GetEconomicLifeInMonths(usefulLifeYears);
            return ecconomicLife;
        }

        public double CalculateMonthlyDepreciationCharge(DateTime startFinancialYear, DateTime endFinancialYear, double acquisitionCost, double residualCost)
        {
            return (acquisitionCost - residualCost)/((endFinancialYear.Year - startFinancialYear.Year)*12);
        }
        private static int GetEconomicLifeInMonths(int usefulLifeYears)
        {
            return usefulLifeYears * 12;
        }
    }
}