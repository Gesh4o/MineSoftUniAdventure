namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        private const string RequestMethod = "POST";

        public override bool IsValid(string requestMethod)
        {
            return !string.IsNullOrEmpty(requestMethod) && requestMethod.ToUpper() == RequestMethod;
        }
    }
}