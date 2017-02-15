namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        private const string RequestMethod = "GET";

        public override bool IsValid(string requestMethod)
        {
            return !string.IsNullOrEmpty(requestMethod) && requestMethod.ToUpper() == RequestMethod;
        }
    }
}