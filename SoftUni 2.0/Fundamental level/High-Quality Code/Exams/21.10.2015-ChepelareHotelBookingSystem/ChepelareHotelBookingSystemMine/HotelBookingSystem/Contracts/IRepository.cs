namespace HotelBookingSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Used to store data .
    /// </summary>
    /// <typeparam name="T">Type of the variables which will be stored in the data.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all elements in current repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets specific item in repository by passed ID value.
        /// </summary>
        /// <param name="id">Value indicator of the wanted from the data element.</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Adds new element to data.
        /// </summary>
        /// <param name="item">Element to add.</param>
        void Add(T item);

        /// <summary>
        /// Changes the element wiht specific ID.
        /// </summary>
        /// <param name="id">ID of the element which will be changed.</param>
        /// <param name="newItem">Element value with which element will be changed.</param>
        /// <returns></returns>
        bool Update(int id, T newItem);

        /// <summary>
        /// Delete specific element with passed ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}