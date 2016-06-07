namespace _01.InstructionSet
{
    using System;
    using System.Numerics;

    public class InstructionSetMain
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] codeArgs = command.Split(' ');

                BigInteger result = new BigInteger(0);
                long operandOne;
                long operandTwo;
                switch (codeArgs[0])
                {
                    case "INC":
                        operandOne = long.Parse(codeArgs[1]);
                        result = operandOne + 1;
                        break;
                    case "DEC":
                        operandOne = long.Parse(codeArgs[1]);
                        result = operandOne - 1;
                        break;
                    case "ADD":
                        operandOne = long.Parse(codeArgs[1]);
                        operandTwo = long.Parse(codeArgs[2]);
                        result = new BigInteger(operandOne) + new BigInteger(operandTwo);
                        break;
                    case "MLA":
                        operandOne = long.Parse(codeArgs[1]);
                        operandTwo = long.Parse(codeArgs[2]);
                        result = new BigInteger(operandOne) * new BigInteger(operandTwo);
                        break;
                }

                Console.WriteLine(result);
                command = Console.ReadLine();
            }
        }
    }
}