namespace UniversityLearningSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface used to provide data about the selected command from the input.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Provides the name of the action to be performed.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Provides the controller name from which action will be made. Note that different controller have different views.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Parameters are needed to be passed on action invocation in order to perform action. Note that not all actions need parameters.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}