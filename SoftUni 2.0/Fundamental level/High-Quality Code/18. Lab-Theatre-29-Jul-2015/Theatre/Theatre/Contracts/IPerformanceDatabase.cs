namespace Theatre.Contracts
{
    using System;
    using System.Collections.Generic;
    using Theatre.Exceptions;

    /// <summary>
    /// Interface for database used in the engine engine.
    /// </summary>
    /// <see cref="IEngine"/>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Add theatre to database.
        /// </summary>
        /// <param name="theatreName">Variable for theatre name value.</param>
        /// <exception cref="DuplicateTheatreException"></exception>
        void AddTheatre(string theatreName);

        
        /// <summary>
        /// Returns collection from all theatres.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds new performance to theater.
        /// </summary>
        /// <param name="theatreName">
        /// Variable indicating where performance will be played.
        /// </param>
        /// <param name="performanceTitle">
        /// Name of performance.
        /// </param>
        /// <param name="startDateTime">
        /// Indicates when the performance is starting.
        /// </param>
        /// <param name="performanceDuration">
        /// Indicates how long the performance will be.
        /// </param>
        /// <param name="ticketPrice">
        /// Variable for ticket price of the performance.
        /// </param>
        /// <exception cref="TheatreNotFoundException"></exception>
        /// <exception cref="TimeDurationOverlapException"></exception>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan performanceDuration, decimal ticketPrice);

        /// <summary>
        /// List every performance in database.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Performance> ListAllPerformances();


        /// <summary>
        /// List every performance in selected theater.
        /// </summary>
        /// <param name="theatreName">
        /// Indicates which theater's performances will be shown.
        /// </param>
        /// <returns></returns>
        /// <exception cref="TheatreNotFoundException"></exception>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}