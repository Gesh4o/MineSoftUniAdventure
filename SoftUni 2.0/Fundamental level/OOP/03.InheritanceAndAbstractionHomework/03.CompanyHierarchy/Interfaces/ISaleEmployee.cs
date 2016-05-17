namespace _03.CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface ISaleEmployee :IEmployee
    {
        IEnumerable<Sale> Sales { get; }

    }
}
