namespace _03.CompanyHierarchy.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDeveloper :IEmployee
    {
        IEnumerable<Project> Project { get; }
        void CloseProject(Project project);
    }
}
