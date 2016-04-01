import java.math.BigInteger;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class _03_SoftUniNumerals {
    private static final String Zero = "aa";
    private static final String One = "aba";
    private static final String Two = "bcc";
    private static final String Three = "cc";
    private static final String Four = "cdc";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, Integer> numbersByString = new HashMap<>();
        numbersByString.put(Zero, 0);
        numbersByString.put(One, 1);
        numbersByString.put(Two, 2);
        numbersByString.put(Three, 3);
        numbersByString.put(Four, 4);

        String resultedNumber = "";
        String input = scanner.nextLine();
        while (input.length() >= 0){
            if (input.startsWith(Zero)){
                resultedNumber += numbersByString.get(Zero).toString();
                input = input.substring(Zero.length());
            }else if(input.startsWith(One)){
                resultedNumber += numbersByString.get(One).toString();
                input = input.substring(One.length());
            }else if(input.startsWith(Two)){
                resultedNumber += numbersByString.get(Two).toString();
                input = input.substring(Two.length());
            }else if(input.startsWith(Three)){
                resultedNumber += numbersByString.get(Three).toString();
                input = input.substring(Three.length());
            }else if(input.startsWith(Four)){
                resultedNumber += numbersByString.get(Four).toString();
                input = input.substring(Four.length());
            }else{
                break;
            }
        }

        BigInteger endResult = new BigInteger("0");
        
        for (int i = 0; i < resultedNumber.length(); i++) {
            Integer digit = Integer.parseInt(Character.toString(resultedNumber.charAt(resultedNumber.length() - 1 - i)));
            BigInteger addition = CustomPower(i,digit);
            endResult = endResult.add(addition);
        }

        System.out.println(endResult);
    }

    private static BigInteger CustomPower(int i, Integer digit) {
        BigInteger result = new BigInteger("5");
        result = result.pow(i);

        result = result.multiply(new BigInteger(digit.toString()));
        return result;
    }
}
