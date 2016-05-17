import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class _06_SaveAnCustomObjectInAFile {
    private static final String destinationPath ="src\\course.save";
    public static void main(String[] args) {
        Course mathCourse = new Course("Math",15);
        try(ObjectOutputStream objectOutputStream = new ObjectOutputStream(new FileOutputStream(destinationPath))){
            objectOutputStream.writeObject(mathCourse);
        }
        catch (IOException e){
            System.out.println(e);
        }

        try(ObjectInputStream objectOutputStream = new ObjectInputStream(new FileInputStream(destinationPath))){
             Course course = (Course)objectOutputStream.readObject();

            System.out.println(course.getName());
        }
        catch (IOException  | ClassNotFoundException e){
            System.out.println(e);
        }

    }
}
