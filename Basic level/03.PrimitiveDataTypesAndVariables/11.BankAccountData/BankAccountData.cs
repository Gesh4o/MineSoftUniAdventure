using System;

class BankAccountData
{
    static void Main()
    {
        string firstName = "Martin";
        string middleName = "Borislavov";
        string lastName = "Nemartinov"; // name is a joke
        decimal balance = 11115.545424324342M;
        string bankName = "Richmen\'s bank";
        string iBan =  "BG70 RMCR 7000 1532 3333 33";
        long cardNumber0 = 111122223333L;
        long cardNumber1 = 1111222233334444L;
        long cardNumber2 = 1111111111111111L;
        Console.WriteLine("User: {0} {1} {2}\nBalace: {3}\nBank: {4}\nIBAN: {5}\nCard №1: " + (cardNumber0.ToString("D16")) + "\nCard №2: {7}\nCard №3: {8}", firstName, middleName, lastName, balance, bankName, iBan, cardNumber0, cardNumber1, cardNumber2);

    }
}