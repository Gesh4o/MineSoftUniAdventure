﻿namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using Interfaces.Generic;
    using System;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string view, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(view));
            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}