using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Annie";
        string lastName = "Johnson";
        byte age = 23;
        char gender = 'f';
        long personalID = 8304412507l;
        int uniquePersonalNumber = 27533571;
        Console.WriteLine(
        "First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonalID: {4}\nUnique Personal Number: {5}", firstName, lastName, age, gender, personalID, uniquePersonalNumber);
    }
}