namespace SimpleMVC.App.MVC.ViewEngine
{
    using Interfaces;
    using System;

    public class ActionResult : IActionResult
    {
        /// <summary>
        /// Makes new instance of <seealso cref="IActionResult"/>.
        /// </summary>
        /// <param name="view">
        /// This is the full name of the view we want to display
        /// e.g. - SimpleMvc.App.Views.Home.Index.
        /// </param>
        public ActionResult(string view)
        {
            this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(view));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}