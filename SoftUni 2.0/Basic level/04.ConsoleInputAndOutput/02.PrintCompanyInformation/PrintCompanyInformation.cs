using System;

class PrintCompanyInformation
{
    static void Main()
    {
        string companyName = "BulgTech";
        string companyAddress = "gr.Sofia, ulitca Gornonanadolnishte 6A";
        string companyPhone = "+359 00 000 0000";
        string companyFax = "No fax";
        string companyWebsite = "http:\\bulgtech.com";
        string managerFirstName = "Nekuv";
        string managerLastName = "Pich";
        int age = 23;
        string managerPhone = "+359 10 100 1000";
        string ch = "|";

        Console.WriteLine("Company name: {1} {0,-15}",companyName, ch.PadLeft(16,' '));
        Console.WriteLine("Company adrress: {1} {0,-15}",companyAddress, ch.PadLeft(13, ' '));
        Console.WriteLine("Company phone: {1,15} {0,-15}", companyPhone, ch);
        Console.WriteLine("Company FAX:  {1,16} {0,-15}", companyFax, ch);
        Console.WriteLine("Website: " + " {1,20}" + " {0,-15}", companyWebsite, ch);
        Console.WriteLine("Manager first name: " + " {1,9}" + " {0,-15}", managerFirstName, ch);
        Console.WriteLine("Manager last name: " + " {1,10}" + " {0,-15}", managerLastName, ch);
        Console.WriteLine("Manager's age: " + " {1,14}" + " {0,-15}", age, ch);
        Console.WriteLine("Manager's phone: " + " {1,12}" + " {0,-15}", managerPhone, ch);
        Console.WriteLine("{0}"+"{1,22}",companyName, ch );
        Console.WriteLine("Address: gr.Sofia, ulitca " + "{1,4} " + "\nGornonanadolnishte 6A" + "{1,9} ", companyAddress, ch);
        Console.WriteLine("Fax: {0}"+"{1,19}", companyFax, ch);
        Console.WriteLine("Website: {0} " + "{1,2}", companyWebsite, ch);
        Console.WriteLine("Manager: {0} {1} ( age: {2}"+ "{4}" + "\ntel.{3})"+"{4,9}",managerFirstName, managerLastName, age, managerPhone, ch);

    }
}