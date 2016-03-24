import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class _02_ALLCAPITALS {
    public static void main(String[] args) {
        String path = "src\\lines.txt";

        try (BufferedReader bufferedReader = new BufferedReader(
                new InputStreamReader(
                        new FileInputStream(path)))){

            String input = bufferedReader.readLine();

            while(input != null){
                System.out.println(input.toUpperCase());
                input = bufferedReader.readLine();
            }
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }
    }
}
