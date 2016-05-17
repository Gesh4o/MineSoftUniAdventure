namespace UniversityLearningSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides methods with which data can be collected and extended.
    /// </summary>
    /// <typeparam name="T">Type of the collected data.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Provides add functionality to the data layer.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        void Add(T item);

        /// <summary>
        /// Gets specific item by ID.
        /// </summary>
        /// <param name="id">ID of the item we want to find.</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Gets all information in the current data.
        /// </summary>
        /// <returns>Collection of all the data in data layer.</returns>
        IEnumerable<T> GetAll();
    }
}