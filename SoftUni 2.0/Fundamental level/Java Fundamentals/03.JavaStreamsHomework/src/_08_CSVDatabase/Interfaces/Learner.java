package _08_CSVDatabase.Interfaces;

public interface Learner {
    String getFirstName();

    String getLastName();

    String getTownName();

    Integer getAge();

    Iterable<Course> getCourses();

    void addCourse(Course grade);
}
