namespace _02.CreateUser.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value as string;

            if (password == null && 
                !password.Any(c => char.IsUpper(c)) && 
                !password.Any(c => char.IsLower(c)) && 
                !password.Any(c => char.IsDigit(c)) &&
                !password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return false;
            }

            return true;
        }
    }
}
