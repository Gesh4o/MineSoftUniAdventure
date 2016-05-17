import java.io.*;

public class _02_ALLCAPITALS {
    public static void main(String[] args) {
        String path = "src\\lines.txt";

        StringBuilder text = new StringBuilder();
        try (BufferedReader bufferedReader = new BufferedReader(
                new FileReader(path))){

            String input = bufferedReader.readLine();

            while(input != null){
                text.append(input.toUpperCase()).append("\r\n");
                input = bufferedReader.readLine();
            }
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }
        try(PrintWriter printWriter = new PrintWriter(new FileWriter(path))){
            printWriter.print(text.toString());
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }
    }
}
