import java.util.Scanner;

public class _12_CalculateFactorial {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer factorialNumber = scanner.nextInt();

        int factorialResult = FindFactorial(factorialNumber);

        System.out.println(factorialResult);
    }

    private static int FindFactorial(Integer factorialNumber) {
        int result = 1;
        if (factorialNumber == 0){
            return result;
        }

        result = factorialNumber * FindFactorial(factorialNumber - 1);

        return result;
    }
}
