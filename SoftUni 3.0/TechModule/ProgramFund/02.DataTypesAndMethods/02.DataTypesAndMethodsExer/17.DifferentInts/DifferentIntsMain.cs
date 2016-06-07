namespace _17.DifferentInts
{
    using System;

    public class DifferentIntsMain
    {
        public static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();
            bool canBeParsed = true;
            try
            {
                long number = long.Parse(numberAsString);
            }
            catch (Exception)
            {
                canBeParsed = false;
                Console.WriteLine("{0} can't be fitted anywhere", numberAsString);
            }

            if (canBeParsed)
            {
                Console.WriteLine("{0} can be fitted in:", numberAsString);
                try
                {
                    sbyte number = sbyte.Parse(numberAsString);
                    Console.WriteLine("* sbyte");
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    byte number = byte.Parse(numberAsString);
                    Console.WriteLine("* byte");
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    short number = short.Parse(numberAsString);
                    Console.WriteLine("* short");
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    ushort number = ushort.Parse(numberAsString);
                    Console.WriteLine("* ushort");
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    int number = int.Parse(numberAsString);
                    Console.WriteLine("* int");
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    uint number = uint.Parse(numberAsString);
                    Console.WriteLine("* uint");
                }
                catch (Exception)
                {
                    // ignored
                }

                Console.WriteLine("* long");
            }
        }
    }
}
