namespace InheritanceAndPolymorphism.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string CourseName { get; }

        string TeacherName { get; }

        IEnumerable<IStudent> Students { get; }

        /// <summary>
        /// Add several student members into the course.
        /// </summary>
        /// <param name="studentToAdd"></param>
        void AddStudents(params IStudent[] studentToAdd);

        /// <summary>
        /// Removes a given student from the course's students list.
        /// </summary>
        /// <param name="studentToRemove"></param>
        void RemoveStudent(IStudent studentToRemove);
    }
}
