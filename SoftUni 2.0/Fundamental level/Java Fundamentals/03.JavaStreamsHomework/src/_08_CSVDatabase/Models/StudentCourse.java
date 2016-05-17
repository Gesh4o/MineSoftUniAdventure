package _08_CSVDatabase.Models;

import _08_CSVDatabase.Interfaces.Course;
import java.util.ArrayList;

public class StudentCourse implements Course {
    private String courseName;

    private ArrayList<Double> grades;

    public StudentCourse(String courseName, Double grade) {
        this(courseName);
        this.addGrade(grade);
    }

    public StudentCourse(String courseName) {
        this.courseName = courseName;
        this.grades = new ArrayList<>();
    }

    @Override
    public String getCourseName() {
        return this.courseName;
    }

    @Override
    public Iterable<Double> getGrades() {
        return this.grades;
    }

    public void addGrade(Double grade){
        if (grade  < 2.0 || grade > 6.0){
            throw new NullPointerException("Course grade value is not valid!");
        }

        this.grades.add(grade);
    }

    @Override
    public String toString() {

        // # Math: 2.00, 2.00, 3.50
        StringBuilder gradesStringBuilder = new StringBuilder();
        if (this.grades.size() == 1){
            gradesStringBuilder.append(String.format("%.2f%n", this.grades.get(0)));
        }
        else{
            for (int i = 0; i < this.grades.size(); i++) {
                Double grade = this.grades.get(i);
                if (i == this.grades.size() - 1){
                    gradesStringBuilder.append(String.format("%.2f%n",grade));

                }
                else {
                    gradesStringBuilder.append(String.format("%.2f, ",grade));
                }
            }
        }

        String result = String.format("$ %s: %s", this.getCourseName(), gradesStringBuilder.toString());

        return result;
    }

    private void setCourseName(String name){
        if (name == null || name.length() == 0){
            throw new NullPointerException("Course name is null or empty!");
        }

        this.courseName = name;
    }

}
