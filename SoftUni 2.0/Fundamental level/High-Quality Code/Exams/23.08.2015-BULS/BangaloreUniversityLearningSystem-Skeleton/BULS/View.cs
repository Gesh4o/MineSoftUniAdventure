namespace buls.Infrastructure
{
    using System.Text;
    using Interfaces;

    public abstract class View : IView
    {
        public View(object model)
        {
            this.model = model;
        }

        public object model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        internal virtual void BuildViewResult(StringBuilder viewResult)
        {
        }
    }
}
