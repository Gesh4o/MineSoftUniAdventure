namespace UniversityLearningSystem.Utilities
{
    using System;

    /// <summary>
    /// Class providing validating utilities.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks if string has expected length and if not informs the user.
        /// </summary>
        /// <param name="value">
        /// The string value to be checked.
        /// </param>
        /// <param name="expectedMinimalLength">
        /// Minimal expected length.
        /// </param>
        /// <param name="valueName">
        /// Name of string value.
        /// </param>
        /// <see cref="ArgumentException"/>
        public static void ValidateStringLength(string value, int expectedMinimalLength, string valueName)
        {
            if (string.IsNullOrEmpty(value) || value.Length < expectedMinimalLength)
            {
                const string Message = "The {0} must be at least {1} symbols long.";
                throw new ArgumentException(string.Format(Message, valueName, expectedMinimalLength));
            }
        }
    }
}
