namespace SoftUniGameStore.App.BindingModels.User
{
    using System.Linq;

    public class UserRegisterBindingModel : AbstractBindingModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        public override bool IsValid()
        {
            bool isEmailValid = this.Email.Contains("@") && this.Email.Contains(".");

            // Maybe optimize.
            bool isPasswordValid = this.Password.Any(char.IsUpper) && this.Password.Any(char.IsDigit) && this.Password.Any(char.IsLower) && this.Password == this.ConfirmPassword;
            
            return isEmailValid && isPasswordValid;
        }
    }
}
