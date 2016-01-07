namespace _03.CompanyHierarchy.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IProject
    {
        string ProjectName { get; set; }
        string StartDate { get; set; }
        string Details { get; set; }
        string State { get; set; }
    }
}
