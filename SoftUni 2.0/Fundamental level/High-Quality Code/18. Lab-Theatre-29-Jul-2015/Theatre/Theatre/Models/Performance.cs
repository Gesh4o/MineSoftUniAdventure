namespace Theatre
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatreName, string performanceTitle, DateTime date, TimeSpan timeSpan, decimal ticketPrice)
        {
            this.TheatreName = theatreName;
            this.PerformanceTitle = performanceTitle;
            this.Date = date;
            this.TimeSpan = timeSpan;
            this.TicketPrice = ticketPrice;
        }

        public string TheatreName { get; private set; }
        public string PerformanceTitle { get; private set; }
        public DateTime Date { get; set; }

        public TimeSpan TimeSpan { get; private set; }
        protected internal decimal TicketPrice { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int tmp = this.Date.CompareTo(otherPerformance.Date); return tmp;
        }

        public override string ToString()
        {
            string result = string.Format(
                "Performance(Tr32: {0}; Tr23: {1}; Date: {2}, TimeSpan: {3}, Gia: {4})",
                this.TheatreName,
                this.PerformanceTitle,
                this.Date.ToString("dd.MM.yyyy HH:mm"), 
                this.TimeSpan.ToString("hh':'mm"), 
                this.TicketPrice.ToString("f2"));

            return result;
        }
    }
}