namespace _12.PhoneBook
{
    using System;
    using System.Collections.Generic;

    public class PhonebookMain
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandInfo = command.Split(' ');
                string commmandName = commandInfo[0];

                string contactName;
                switch (commmandName)
                {
                    case "A":
                        contactName = commandInfo[1];
                        string contactNumber = commandInfo[2];
                        if (phoneBook.ContainsKey(contactName))
                        {
                            phoneBook.Remove(contactName);
                        }

                        phoneBook.Add(contactName, contactNumber);

                        break;
                    case "S":
                        contactName = commandInfo[1];
                        if (phoneBook.ContainsKey(contactName))
                        {
                            Console.WriteLine($"{contactName} -> {phoneBook[contactName]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {contactName} does not exist.");
                        }
                        break;
                    case "ListAll":
                        foreach (KeyValuePair<string, string> phoneNumber in phoneBook)
                        {
                            Console.WriteLine($"{phoneNumber.Key} -> {phoneNumber.Value}");
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
