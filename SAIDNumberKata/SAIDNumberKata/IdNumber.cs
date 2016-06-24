using System;
using NUnit.Framework;

namespace SAIDNumberKata
{
    public class IdNumber
    {
        public IdNumberParts ExtractIDParts(string idNumber)
        {
            var idNumberParts = new IdNumberParts
            {
                DateOfBirth = GetDateOfBirth(idNumber),
                Gender = GetGender(idNumber),
                Citizenship = GetCitizenship(idNumber)
            };
            return idNumberParts;
        }

        private static string GetCitizenship(string idNumber)
        {
            var citizenship = idNumber.Substring(10, 1);
            return int.Parse(citizenship) == 0 ? "SA" : "Other";
        }

        private static Gender GetGender(string idNumber)
        {
            var gender = idNumber.Substring(6, 1);
            return int.Parse(gender) <= 4 ? Gender.Female : Gender.Male;
        }

        private static string GetDateOfBirth(string idNumber)
        {
            var day = idNumber.Substring(4, 2);
            var month = idNumber.Substring(2, 2);
            var year = idNumber.Substring(0, 2);
            var century = GetCentury(year);
            var fullYear = century + year;

            var dateOfBirth = string.Format("{0}-{1}-{2}", day, month, fullYear);
            return dateOfBirth;
        }

        public static string GetCentury(string year)
        {
            return int.Parse(year) <= 20 ? "20" : "19";
        }
    }
}