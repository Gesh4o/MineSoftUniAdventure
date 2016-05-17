namespace _17.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // Just Judge things.. you know
    public class OfficeStuffMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Company> companies = new List<Company>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputData = input.Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string companyName = inputData[0];
                string officeObjectName = inputData[2];
                int count = int.Parse(inputData[1]);

                if (companies.Any(c => c.Name == companyName))
                {
                    companies.First(c => c.Name == companyName).AddOfficeSupply(officeObjectName, count);
                }
                else
                {
                    Company company = new Company(companyName);
                    company.AddOfficeSupply(officeObjectName, count);
                    companies.Add(company);
                }
            }

            companies = companies.OrderBy(c => c.Name).ToList();
            foreach (Company company in companies)
            {
                Console.WriteLine(company);
            }
        }
    }

    public class Company
    {
        private IDictionary<string, OfficeStuff> officeSupplies;

        public Company(string name)
        {
            this.Name = name;
            this.officeSupplies = new Dictionary<string, OfficeStuff>();
        }

        public string Name { get; private set; }

        public void AddOfficeSupply(string officeObject, int count)
        {
            if (officeObject == null)
            {
                throw new ArgumentNullException(nameof(officeObject));
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count of office stuff cannot be negative!");
            }

            if (this.officeSupplies.ContainsKey(officeObject))
            {
                this.officeSupplies[officeObject].AddCount(count);
            }
            else
            {
                OfficeStuff officeStuff = new OfficeStuff(officeObject, count);
                this.officeSupplies.Add(officeObject, officeStuff);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: ", this.Name);
            result.AppendLine(string.Join(", ", this.officeSupplies.Values));

            return result.ToString().Trim();
        }
    }

    public class OfficeStuff
    {
        public OfficeStuff(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public string Name { get; private set; }

        public int Count { get; private set; }

        public void AddCount(int additionalCount)
        {
            this.Count += additionalCount;
        }

        public override string ToString()
        {
            string result = $"{this.Name}-{this.Count}";
            return result;
        }
    }
}
