import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class _05_SaveAnArrayListOfDoubles {
    private static final String destinationPath = "src\\doubles.list";
    public static void main(String[] args) {
        ArrayList<Double> doubles = new ArrayList<>();
        doubles.add(5.5);
        doubles.add(2.1);
        doubles.add(3.4);
        doubles.add(4.1);
        doubles.add(16.5);
        doubles.add(0.0);


        try(ObjectOutputStream objectOutputStream = new ObjectOutputStream(new FileOutputStream(destinationPath))){
            objectOutputStream.writeObject(doubles);
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }

        try(ObjectInputStream objectOutputStream = new ObjectInputStream(new FileInputStream(destinationPath))){
            List<Double> array = (ArrayList<Double>)objectOutputStream.readObject();

            System.out.println(array);
        }
        catch (IOException | ClassNotFoundException e){
            System.out.println(e);
        }
    }
}
