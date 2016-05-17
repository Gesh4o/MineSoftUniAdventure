namespace Exceptions_Homework
{
    using System;
    using Exceptions_Homework.Entities;
    using Exceptions_Homework.Entities.Exams;
    using Exceptions_Homework.Utilities;

    public class ExceptionsMain
    {
        public static void Main()
        {
            try
            {
                var substr = StringUtilities.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = StringUtilities.Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                ////var allarr = StringUtilities.Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
                ////Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = StringUtilities.Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));

                Console.WriteLine(StringUtilities.ExtractEnding("I love C#", 2));
                Console.WriteLine(StringUtilities.ExtractEnding("Nakov", 4));
                Console.WriteLine(StringUtilities.ExtractEnding("beer", 4));

                ////Console.WriteLine(ExtractEnding("Hi", 100));

                int firstNumber = 23;
                MathUtilities.CheckPrime(firstNumber);

                int secondNumber = 33;
                MathUtilities.CheckPrime(secondNumber);

                Student peter = new Student("Peter", "Petrov");
                peter.AddExam(new SimpleMathExam(2));
                peter.AddExam(new CSharpExam(55));
                peter.AddExam(new CSharpExam(100));
                peter.AddExam(new SimpleMathExam(1));
                peter.AddExam(new CSharpExam(0));

                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);                
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
