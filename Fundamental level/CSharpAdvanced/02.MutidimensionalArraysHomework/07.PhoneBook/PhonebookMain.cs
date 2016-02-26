namespace _07.PhoneBook
{
    using System;
    using System.Collections.Generic;

    public class PhonebookMain
    {
        public static void Main()
        {
            var phonesByNames = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "search")
            {
                string[] nameAndPhone = input.Split('-');
                if (!phonesByNames.ContainsKey(nameAndPhone[0]))
                {
                    phonesByNames.Add(nameAndPhone[0], new List<string>());
                    phonesByNames[nameAndPhone[0]].Add(nameAndPhone[1]);
                }
                else
                {
                    phonesByNames[nameAndPhone[0]].Add(nameAndPhone[1]);
                }

                input = Console.ReadLine();
            }

            string searchedName = Console.ReadLine();
            while (searchedName != string.Empty)
            {
                if (phonesByNames.ContainsKey(searchedName))
                {
                    Console.WriteLine("{0} -> {1}", searchedName, string.Join(" ", phonesByNames[searchedName]));
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", searchedName);
                }

                searchedName = Console.ReadLine();
            }
        }
    }
}
