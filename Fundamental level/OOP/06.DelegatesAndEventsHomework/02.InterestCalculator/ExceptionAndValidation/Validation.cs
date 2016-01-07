namespace _02.InterestCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Validation
    {
        public static void CheckIsNumberNotNegative<T>(T number,string type) where T : IComparable
        {
            if (number.CompareTo(0)< 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(ExceptionMessages.NumberIsNegative, type));
            }
        }

        //public static void CheckIsEmptyOrNull(string inputedString, string type)
        //{
        //    if (string.IsNullOrEmpty(inputedString))
        //    {
        //        throw new ArgumentNullException(string.Format(ExceptionMessages.ValueIsNullOrEmpty, type));
        //    }
        //}
    }
}
