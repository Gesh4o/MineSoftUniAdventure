package _08_CSVDatabase.Models;

import _08_CSVDatabase.Interfaces.Course;
import _08_CSVDatabase.Interfaces.Learner;

import java.util.ArrayList;

public class Student implements Learner {
    private String firstName;

    private String lastName;

    private String town;

    private Integer age;

    private ArrayList<Course> grades;

    public Student(String firstName, String lastName, Integer age, String town) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.town = town;
        this.grades = new ArrayList<>();
    }

    @Override
    public String getFirstName() {
        return this.firstName;
    }

    @Override
    public String getLastName() {
        return this.lastName;
    }

    @Override
    public String getTownName() {
        return this.town;
    }

    @Override
    public Integer getAge() {
        return this.age;
    }

    @Override
    public Iterable<Course> getCourses() {
        return this.grades;
    }

    @Override
    public void addCourse(Course grade) {
        if (this.grades.stream().anyMatch(g -> g.getCourseName().equals(grade.getCourseName()))){
            Course course = this.grades.stream().filter(g -> g.getCourseName().equals(grade.getCourseName())).findFirst().get();

            Double value = 0.0;
            for (Double gradeValue: grade.getGrades()) {
                value = gradeValue;
                break;
            }

            course.addGrade(value);
        }else{
            this.grades.add(grade);
        }
    }

    @Override
    public String toString() {
        // 	Georgi Ivanov (age: 14, town: Novi Pazar)
        // 	# Math: 2.00, 2.00, 3.50
        // 	# Literature: 4.00, 5.25


        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append(String.format(
                "%s %s (age: %d, town: %s)%n",
                this.getFirstName(),
                this.getLastName(),
                this.getAge(),
                this.getTownName()));

        for (Course grade : grades) {
            stringBuilder.append(grade.toString());
        }

        return stringBuilder.toString().trim();
    }
}
