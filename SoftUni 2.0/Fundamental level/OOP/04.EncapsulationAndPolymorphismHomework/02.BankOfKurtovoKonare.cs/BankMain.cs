namespace BankOfKurtovoKonare.cs
{
    using BankAccounts;
    using Customers;
    using System;

    class BankMain
    {
        static void Main()
        {
            IndividualCustomer Bobo = new IndividualCustomer("Bobo");
            CompanyCustomer Komfo = new CompanyCustomer("Komfo");

            DepositAccount firstDeposit = new DepositAccount(Bobo, 800, 15);
            LoanAccoint secondDeposit = new LoanAccoint(Komfo, 2299, 19);

            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , firstDeposit.Customer.Name, firstDeposit.Balance, firstDeposit.CalculateInterest(12));

            firstDeposit.DepositMoney(600);
            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , firstDeposit.Customer.Name, firstDeposit.Balance, firstDeposit.CalculateInterest(12));


            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , secondDeposit.Customer.Name, secondDeposit.Balance, secondDeposit.CalculateInterest(2));

            Console.WriteLine();
            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , secondDeposit.Customer.Name, secondDeposit.Balance, secondDeposit.CalculateInterest(6));

            MortgageAccount death = new MortgageAccount(Bobo, 750, 15);
            MortgageAccount metal = new MortgageAccount(Komfo, 1000, 15);

            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , death.Customer.Name, death.Balance, death.CalculateInterest(6));
            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , death.Customer.Name, death.Balance, death.CalculateInterest(7));
            Console.WriteLine();

            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , metal.Customer.Name, metal.Balance, metal.CalculateInterest(12));
            Console.WriteLine("Balance {0}: {1:#.##} lv.; Interest: {2:0.##}"
                , metal.Customer.Name, metal.Balance, metal.CalculateInterest(24));
        }
    }
}
