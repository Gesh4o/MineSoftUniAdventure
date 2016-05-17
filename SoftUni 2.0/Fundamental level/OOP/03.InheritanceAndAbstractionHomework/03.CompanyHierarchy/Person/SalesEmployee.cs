namespace _03.CompanyHierarchy
{
    using System;
    using Interfaces;
    using System.Collections.Generic;

    class SalesEmployee : RegularEmployee, ISaleEmployee
    {
        private List<Sale> sales;

        public SalesEmployee(string id, string firstName, string lastName, decimal salary, DepartmentType department)
            :base(id, firstName, lastName, salary ,department)
        {
            this.sales = new List<Sale>();
        }

        //Constructor used when employee is new and does not have any sales yet.

        public IEnumerable<Sale> Sales
        {
            get
            {
                return this.sales;
            }
        }

        public override string ToString()
        {
            string salesInfo = GetSalesInfo(this.sales);
            string result = string.Format("Name: {0} {1} \nID: {2} \nSalary: {3} \nDepartment: {4}\nSales information: \n{5}"
                , this.FirstName, this.LastName, this.ID, this.Salary, this.Department, salesInfo);
            return result;
        }

        private string GetSalesInfo(List<Sale> sales)
        {
            string saleInfo = string.Empty;
            foreach (var sale in sales)
            {
                Sale tempSale = sale;
                saleInfo += string.Format("Sold product: {0} \nSold on: {1}\nProducts price: {2}\n"
                    , sale.ProductName, sale.Date, Convert.ToString(sale.Price));
            }
            return saleInfo;
        }

        public void AddSale(Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentException("Sale cannot be null!");
            }
            this.sales.Add(sale);
        }
    }
}
