import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class _03_CountCharacterTypes {
    public static void main(String[] args) {
        String path = "src\\words.txt";

        try (BufferedReader bufferedReader = new BufferedReader(
                new InputStreamReader(
                        new FileInputStream(path)))){

            String input = bufferedReader.readLine();

            Integer vowelSum = 0;
            Integer consonantSum = 0;
            Integer punctuationSum = 0;

            while(input != null){
                char[] result = input.toCharArray();
                for (char c : result) {
                    if (Character.isAlphabetic(c)) {
                        if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                            vowelSum++;

                        } else {
                            consonantSum++;
                        }
                    }
                    else if(c == '!' || c == ',' || c == '.' || c == '?'){
                        punctuationSum++;
                    }
                }

                System.out.printf("Vowels: %d%n", vowelSum);
                System.out.printf("Consonants: %d%n", consonantSum);
                System.out.printf("Punctuation: %d%n", punctuationSum);

                input = bufferedReader.readLine();
            }
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }
    }
}
