namespace _02.CreateUser.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    // Task 10.
    [AttributeUsage(AttributeTargets.Property)]
    class PasswordValidationAttribute : ValidationAttribute
    {
        private int minLength;
        private int maxLength;

        public PasswordValidationAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
            this.ErrorMessage = ErrorMessage;
        }

        public bool ContainsUppercase { get; set; }

        public bool ContainsLowercase { get; set; }

        public bool ContainsDigit { get; set; }

        public override bool IsValid(object value)
        {
            string password = value as string;

            if (password == null || password.Length < this.minLength || password.Length > this.maxLength)
            {
                return false;
            }

            bool result = true;

            if (this.ContainsDigit)
            {
                result = password.Any(c => char.IsDigit(c));
            }

            if (result && this.ContainsLowercase)
            {
                result = password.Any(c => char.IsLower(c));
            }

            if (result && this.ContainsUppercase)
            {
                result = password.Any(c => char.IsUpper(c));
            }

            return result;
        }
    }
}
