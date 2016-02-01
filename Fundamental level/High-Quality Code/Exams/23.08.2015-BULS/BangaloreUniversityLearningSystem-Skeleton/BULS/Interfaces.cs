using buls.Data;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IBangaloreUniversityDate
    {
        UsersRepository users { get; }
        IRepository<Course> courses { get; }
    }
    public interface Iइंजन
    {
        void रन();
    }
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
    }
    public interface IRoute
    {
        string _controllerName { get; }
        string _actionName { get; }
        IDictionary<string, string> _parameters { get; }
    }
    public interface IView
    {
        object model { get; }
        string Display();
    }
}