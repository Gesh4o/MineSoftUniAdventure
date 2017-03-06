namespace SoftUniGameStore.App.BindingModels.User
{
    public class UserAuthenticationBindingModel : AbstractBindingModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
