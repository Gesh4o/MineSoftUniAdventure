namespace UniversityLearningSystem.Data
{
    using UniversityLearningSystem.Contracts;
    using UniversityLearningSystem.Models;

    public class BangaloreUniversityData : IBangaloreUniversityDate
    {
        public BangaloreUniversityData()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; private set; }

        public IRepository<Course> Courses { get; private set; }
    }
}
