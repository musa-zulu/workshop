using System;

namespace AgeCalculatorKata
{
    public class AgeCalculator
    {
        public int CalculateAge(DateTime birthDate, DateTime givenDate)
        {
            if (IsLessThanCurrentDate(birthDate, givenDate))
                throw new ApplicationException("Current date is before birth date");
            if (IsLeapYear(birthDate.Year) && (givenDate.Month == 02) && (givenDate.Day == 28))
                return GetAge(birthDate, givenDate);
            if (BornOnCurrentYear(birthDate, givenDate))
                return GetDefaultAge();
            if (givenDate.Day < birthDate.Day || givenDate.Month < birthDate.Month)
                return (givenDate.Year - birthDate.Year) - 1;
            return GetAge(birthDate, givenDate);
        }
        
        private static int GetDefaultAge()
        {
            return 0;
        }

        private static int GetAge(DateTime birthDate, DateTime givenDate)
        {
            return givenDate.Year - birthDate.Year;
        }

        private static bool IsLessThanCurrentDate(DateTime birthDate, DateTime givenDate)
        {
            return givenDate.Year < birthDate.Year;
        }

        private static bool BornOnCurrentYear(DateTime birthDate, DateTime givenDate)
        {
            return birthDate == givenDate;
        }

        private static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }
    }
}