namespace UniversityLearningSystem.Contracts
{
    using UniversityLearningSystem.Data;
    using UniversityLearningSystem.Models;

    public interface IBangaloreUniversityDate
    {
        IRepository<Course> Courses { get; }

        UsersRepository Users { get; }
    }
}