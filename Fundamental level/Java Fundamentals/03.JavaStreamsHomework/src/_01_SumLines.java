import java.io.*;

public class _01_SumLines {
    public static void main(String[] args) {
        String path = "src\\lines.txt";

        try (BufferedReader bufferedReader = new BufferedReader(
                new InputStreamReader(
                        new FileInputStream(path)))){

            String input = bufferedReader.readLine();

            while(input != null){
                int charSum = 0;
                char[] result = input.toCharArray();
                for (char c : result) {
                    charSum += (int)c;
                }

                System.out.println(charSum);
                input = bufferedReader.readLine();
            }
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }
    }
}
