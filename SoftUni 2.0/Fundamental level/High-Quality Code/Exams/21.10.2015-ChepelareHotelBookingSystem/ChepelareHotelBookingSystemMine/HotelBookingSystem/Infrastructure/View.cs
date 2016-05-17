namespace HotelBookingSystem.Infrastructure
{
    using System.Text;
    using Contracts;

    public abstract class View : IView
    {
        protected View(object model)
        {
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            string result = viewResult.ToString().Trim();
            return result;
        }

        protected abstract void BuildViewResult(StringBuilder viewResult);
    }
}
