namespace _03.CompanyHierarchy.Interfaces
{
    using System;
    public interface ISale
    {
        string ProductName { get; set; }
        string Date { get; set; }
        decimal Price { get; set; }
    }
}
