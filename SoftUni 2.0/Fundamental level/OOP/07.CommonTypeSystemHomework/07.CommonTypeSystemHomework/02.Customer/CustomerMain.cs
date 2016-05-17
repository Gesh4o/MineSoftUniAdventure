namespace _02.Customer
{
    using System;

    public class CustomerMain
    {
        public static void Main()
        {
            Customer customer = new Customer("Pesho", "Peshev", "Peshev", "123456", "1", "Sofia", "nemaTakuvEmail", CustomerTypes.Diamond);
            Customer customer0 = new Customer("Pesho", "Peshev", "Peshev", "123456", "1", "Sofia", "nemaTakuvEmail", CustomerTypes.Diamond);
            Customer customer1 = new Customer("Pesho", "Peshev", "Peshea", "123456", "1", "Sofia", "nemaTakuvEmail", CustomerTypes.Diamond);
            Customer customer2 = new Customer("Pesho", "Peshev", "Peshev", "1234567", "1", "Sofia", "nemaTakuvEmail", CustomerTypes.Diamond);


            Console.WriteLine(customer.CompareTo(customer0));
            Console.WriteLine(customer.CompareTo(customer1));
            Console.WriteLine(customer.CompareTo(customer2));



        }
    }
}
