namespace Exceptions_Homework.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StringUtilities
    {
        public static T[] Subsequence<T>(T[] array, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array)); // I think the message here will not be useful.
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array.Length), "Array is empty!");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index cannot be negative!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative!");
            }

            if (startIndex + count > array.Length - 1)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        $"The sum of start index and count value- {startIndex + count} is larger then the last index value- {array.Length - 1}!"));
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(array[i]);
            }
            return result.ToArray();
        }

        public static string ExtractEnding(string stringArgument, int count)
        {
            if (stringArgument == null)
            {
                throw new ArgumentNullException(nameof(stringArgument), "String argument cannot be  null!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative!");
            }

            if (count > stringArgument.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be bigger then string argument's length!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = stringArgument.Length - count; i < stringArgument.Length; i++)
            {
                result.Append(stringArgument[i]);
            }
            return result.ToString();
        }
    }
}
