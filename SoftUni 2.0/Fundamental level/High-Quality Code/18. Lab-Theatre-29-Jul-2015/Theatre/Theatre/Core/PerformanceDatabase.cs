namespace Theatre.Core
{
    using System;
    using System.Collections.Generic;
    using Theatre.Contracts;
    using Theatre.Exceptions;


    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> sortedDictionaryStringSortedSetPerformance =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.sortedDictionaryStringSortedSetPerformance[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.sortedDictionaryStringSortedSetPerformance.Keys;
            return theatres;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan performanceDuration, decimal ticketPrice)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.sortedDictionaryStringSortedSetPerformance[theatreName];



            var performanceEnd = startDateTime + performanceDuration;
            if (this.IsPerformanceDateTimeCorrect(performances, startDateTime, performanceEnd))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatreName, performanceTitle, startDateTime, performanceDuration, ticketPrice);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.sortedDictionaryStringSortedSetPerformance.Keys;

            var performanceList = new List<Performance>();
            foreach (var theatre in theatres)
            {
                var performances = this.sortedDictionaryStringSortedSetPerformance[theatre];
                performanceList.AddRange(performances);
            }

            return performanceList;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }
            var performances = this.sortedDictionaryStringSortedSetPerformance[theatreName];
            return performances;
        }

        private bool IsPerformanceDateTimeCorrect(IEnumerable<Performance> performances, DateTime currentPerformanceStartDateTime, DateTime currentPerformanceEndDateTime)
        {
            foreach (var performance in performances)
            {
                var performanceStartDateTime = performance.Date;

                var performanceEndDateTime = performance.Date + performance.TimeSpan;

                bool isCurrentPerformanceTooLateToStartFirstCondition = performanceStartDateTime <= currentPerformanceStartDateTime &&
                                                          currentPerformanceStartDateTime <= performanceEndDateTime;

                bool isCurrentPerformanceTooLateToStartSecondCondition = performanceStartDateTime <= currentPerformanceEndDateTime &&
                                                           currentPerformanceEndDateTime <= performanceEndDateTime;

                bool isCurrentPerformanceTooEarlyToStart = currentPerformanceStartDateTime <= performanceStartDateTime &&
                                                           performanceStartDateTime <= currentPerformanceEndDateTime;

                bool isCurrentPerformanceTooEarlyToStart2 = currentPerformanceStartDateTime <= performanceEndDateTime &&
                                                            performanceEndDateTime <= currentPerformanceEndDateTime;

                var isDateTimeCorrect = isCurrentPerformanceTooLateToStartFirstCondition || isCurrentPerformanceTooLateToStartSecondCondition
                                        || isCurrentPerformanceTooEarlyToStart || isCurrentPerformanceTooEarlyToStart2;

                if (isDateTimeCorrect)
                {
                    return true;
                }
            }

            return false;
        }
    }
}