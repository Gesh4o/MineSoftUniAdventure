namespace VehicleParkSystem.Infrastructure
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using VehicleParkSystem.Contracts;

    public class CommandInfo : ICommand
    {
        public CommandInfo(string str)
        {
            this.ActionName = str.Substring(0, str.IndexOf(' '));
            this.Parameters =
                new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(
                    str.Substring(str.IndexOf(' ') + 1));
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }
    }
}
