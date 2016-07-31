import java.util.Scanner;
import java.util.SortedSet;
import java.util.TreeSet;

public class _06_CompareArrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstLine = scanner.nextLine();
        String secondLine = scanner.nextLine();

        SortedSet<String> set = new TreeSet<>();
        set.add(firstLine);
        set.add(secondLine);

        set.forEach((line) ->{
            String removedSpace = line.replaceAll("\\s+", "");
            System.out.println(removedSpace);
        });

        if (firstLine.equals(secondLine)){
            String removedSpace = firstLine.replaceAll("\\s+", "");
            System.out.println(removedSpace);
        }
    }
}
