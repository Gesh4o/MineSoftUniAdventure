namespace _03.CompanyHierarchy
{
    using System;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Project : IProject
    {
        private string projectName;
        private string startDate;
        private string details;
        private string state;

        public Project(string projectName, string startDate, string details, string state)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Details = details;
            this.State = state;
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name must not be null or empty!");
                }

                this.projectName = value;
            }
        }

        public string StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                string dateBoundary = "01.12.2003";
                DateTime pastBoundary = DateTime.Parse(dateBoundary);
                DateTime futureBoundary = DateTime.Now;
                DateTime currentProjectTime = DateTime.Parse(value);
                if (currentProjectTime > futureBoundary || currentProjectTime < pastBoundary)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The date must in after: {0} and prior {1} !", pastBoundary, futureBoundary));

                }

                this.startDate = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The details must be inputed (detail argument can't be null or empty) !");
                }

                this.details = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }

            set
            {
                string openState = "open";
                string closedState = "closed";
                if (value == openState)
                {
                    this.state = value;
                }
                else if (value == closedState)
                {
                    this.state = value;
                }
                else
                {
                    throw new ArgumentException("The project's state must be \"open\" or \"closed\"");
                }
            }
        }
    }
}
