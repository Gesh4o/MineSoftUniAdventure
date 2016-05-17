namespace UniversityLearningSystem.Models
{
    using System;

    using UniversityLearningSystem.Utilities;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateStringLength(value,Constants.MinimalLectureNameLength, "lecture name");

                this.name = value;
            }
        }
    }
}