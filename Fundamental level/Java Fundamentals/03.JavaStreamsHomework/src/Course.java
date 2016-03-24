import java.io.Serializable;

public class Course implements Serializable {
    private String name;

    private int numberOfStudents;

    public Course(String name, int numberOfStudents) {
        this.numberOfStudents = numberOfStudents;
        this.name = name;
    }

    public int getNumberOfStudents() {
        return this.numberOfStudents;
    }

    public String getName() {
        return this.name;
    }
}
