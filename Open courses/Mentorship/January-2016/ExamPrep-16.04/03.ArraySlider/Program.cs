using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ArraySlider
{
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] sequence = Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(BigInteger.Parse)
                        .ToArray();

            string command = Console.ReadLine();

            int currentIndex = 0;
            while (command != "stop")
            {
                string[] commandInfo = command
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                int offset = int.Parse(commandInfo[0]);
                string @operator = commandInfo[1];
                int operand = int.Parse(commandInfo[2]);

                currentIndex = currentIndex + offset;

                currentIndex %= sequence.Length;

                if (currentIndex < 0)
                {
                    currentIndex = sequence.Length - Math.Abs(currentIndex);
                }

                switch (@operator)
                {
                    case "+":
                        sequence[currentIndex] += operand;
                        break;
                    case "-":
                        sequence[currentIndex] -= operand;
                        if (sequence[currentIndex] < 0)
                        {
                            sequence[currentIndex] = 0;
                        }

                        break;
                    case"*":
                        sequence[currentIndex] *= operand;
                        break;
                    case "/":
                        sequence[currentIndex] /= operand;
                        break;
                    case "&":
                        sequence[currentIndex] &= operand;
                        break;
                    case "|":
                        sequence[currentIndex] |= operand;
                        break;
                    case "^":
                        sequence[currentIndex] ^= operand;
                        break;
                }


                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", sequence));
        }
    }
}
