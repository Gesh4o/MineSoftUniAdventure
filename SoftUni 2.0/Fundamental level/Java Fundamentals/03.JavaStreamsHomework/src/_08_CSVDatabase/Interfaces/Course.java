package _08_CSVDatabase.Interfaces;

public interface Course {
    String getCourseName();

    void addGrade(Double grade);

    Iterable<Double> getGrades();
}
