using System;
using buls.Data;
using Interfaces;
using buls.data;

namespace Data
{
    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public UsersRepository users { get; internal set; }
        public IRepository<Course> courses { get;  protected set; }

        public BangaloreUniversityDate()
        {
            this.users = new UsersRepository();
            this.courses = new Repository<Course>();
        }
    }
}
