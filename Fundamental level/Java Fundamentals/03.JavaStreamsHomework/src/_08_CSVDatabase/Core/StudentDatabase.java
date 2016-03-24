package _08_CSVDatabase.Core;

import _08_CSVDatabase.Interfaces.Course;
import _08_CSVDatabase.Interfaces.Database;
import _08_CSVDatabase.Interfaces.Learner;
import _08_CSVDatabase.Models.Student;
import _08_CSVDatabase.Models.StudentCourse;

import java.io.*;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.TreeMap;

public class StudentDatabase implements Database {
    private static final String StudentsPath = "src\\_08_CSVDatabase\\Core\\Data\\students.txt";
    private static final String GradesPath = "src\\_08_CSVDatabase\\Core\\Data\\grades.txt";

    private TreeMap<String, Learner> studentsByName;
    private HashMap<Integer, Learner> studentsById;
    private Integer id;

    public StudentDatabase() {
        this.studentsByName = new TreeMap<>();
        this.studentsById = new HashMap<>();
        this.id = 1;
        this.initializeStudents();
        this.initializeGrades();

        if (this.studentsById.keySet().size() > 0) {
            this.id = this.studentsById.keySet().stream().max(Comparator.naturalOrder()).get() + 1;
        }
    }

    @Override
    public Learner findByName(String name) {
        if (name == null || name.length() == 0) {
            throw new NullPointerException("Cannot find student with null or empty name!");
        }

        Learner student = null;
        if (this.studentsByName.containsKey(name)) {
            student = this.studentsByName.get(name);
        }

        return student;
    }

    @Override
    public Learner findById(int id) {
        Learner student = null;
        if (this.studentsById.containsKey(id)) {
            student = this.studentsById.get(id);
        }

        return student;
    }

    @Override
    public String deleteById(int id) {
        String result = null;
        Boolean isValid = checkIsValidId(id);
        if (!isValid) {
            result = "Student does not exist!";
        }

        if (this.studentsById.containsKey(id)) {
            Learner student = this.studentsById.get(id);
            this.studentsById.remove(id);
            this.studentsByName.remove(String.format("%s %s", student.getFirstName(), student.getLastName()));

            deleteStudentInfo(id, StudentsPath);
            deleteStudentInfo(id, GradesPath);
        } else {
            result = "Student does not exist!";
        }

        return result;
    }

    @Override
    public String updateById(int id) {
        String result = null;
        Boolean isValid = checkIsValidId(id);
        if (!isValid) {
            result = "Student does not exist!";
        } else {
            updateStudentGrades(id);
        }

        return result;
    }

    @Override
    public String insertStudent(Learner student) {
        this.insertStudentAt(student, this.id);

        saveStudentInfo(student);

        this.id++;

        return null;
    }

    @Override
    public String insertGradeById(int id, Course grade) {
        String result = null;
        Boolean isValid = checkIsValidId(id);
        if (!isValid) {
            result = "Student does not exist!";
        }

        if (grade == null) {
            throw new NullPointerException("Grade cannot be null!");
        }

        Learner student = this.findById(id);
        if (student == null) {
            result = "Student does not exist!";
        } else {
            student.addCourse(grade);

            this.studentsById.put(id, student);
        }

        return result;
    }

    private void saveStudentInfo(Learner student) {
        String studentInfo = String.format(
                "%d,%s,%s,%d,%s",
                this.id,
                student.getFirstName(),
                student.getLastName(),
                student.getAge(),
                student.getTownName());
        try(BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(StudentsPath, true))){
            bufferedWriter.write(studentInfo + "\n");

        }catch (IOException ioe){
            //
        }
    }

    private void updateStudentGrades(int id) {
        StringBuilder info = new StringBuilder();
        try (BufferedReader bufferedReader = new BufferedReader(new FileReader(GradesPath))) {
            String line = bufferedReader.readLine();
            while (line != null) {
                if (line.startsWith(Integer.toString(id))) {
                    StringBuilder updatedCourseInfo = new StringBuilder();
                    updatedCourseInfo.append(id).append(",");

                    Learner student = this.findById(id);
                    Iterable<Course> courses = student.getCourses();
                    for (Course course : courses) {
                        updatedCourseInfo.append(course.getCourseName()).append(" ");

                        StringBuilder grades = new StringBuilder();
                        for (Double grade : course.getGrades()) {
                            grades.append(grade).append(" ");
                        }
                    }

                    info.append(updatedCourseInfo.toString()).append("\n");
                } else {
                    info.append(line).append("\n");
                }

                line = bufferedReader.readLine();
            }
        } catch (IOException ioe) {
            //
        }

        try(BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(GradesPath))){
            bufferedWriter.write(info.toString());
        }
        catch (IOException ioe){
            //
        }
    }

    private void deleteStudentInfo(int id, String path) {
        StringBuilder info = new StringBuilder();
        try (BufferedReader bufferedReader = new BufferedReader(new FileReader(path))) {
            String data = bufferedReader.readLine();
            while (data != null) {
                if (!data.startsWith(Integer.toString(id))) {
                    info.append(data).append("\n");
                }

                data = bufferedReader.readLine();
            }

        } catch (IOException ioe) {
            //
        }

        try (BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(path))) {
            bufferedWriter.write(info.toString());
        } catch (IOException ioe) {
            //
        }
    }

    private boolean checkIsValidId(int id) {
        return !(id < 0);
    }

    private void insertStudentAt(Learner student, Integer id) {
        if (student == null) {
            throw new NullPointerException("Cannot add student which is null!");
        }

        if (this.studentsByName.containsKey(String.format("%s %s", student.getFirstName(), student.getLastName()))) {
            // ToDo: throw exception.
        }

        this.studentsById.put(id, student);
        this.studentsByName.put(String.format("%s %s", student.getFirstName(), student.getLastName()), student);
    }

    private void initializeStudents() {

        try (BufferedReader bufferedInputStream = new BufferedReader(new FileReader(StudentsPath))) {
            String inputData = bufferedInputStream.readLine();
            while (inputData != null) {
                String[] inputArgs = inputData.split(",+");

                Integer id = Integer.parseInt(inputArgs[0]);

                String firstName = inputArgs[1];
                String lastName = inputArgs[2];
                Integer age = Integer.parseInt(inputArgs[3]);
                String town = inputArgs[4];

                Learner student = new Student(firstName, lastName, age, town);

                this.insertStudentAt(student, id);

                inputData = bufferedInputStream.readLine();
            }

        } catch (IOException io) {
            // System.out.println(io);
        }
    }

    private void initializeGrades() {

        try (BufferedReader bufferedInputStream = new BufferedReader(new FileReader(GradesPath))) {
            // 5,Math 2.00 2.00 3.50 4.00,Literature 4.00 5.25
            String inputData = bufferedInputStream.readLine();
            while (inputData != null) {
                String[] inputArgs = inputData.split(",+");
                Integer id = Integer.parseInt(inputArgs[0]);
                ArrayList<Course> courses = new ArrayList<>(inputArgs.length - 1);
                for (int i = 1; i < inputArgs.length; i++) {
                    String[] courseInfo = inputArgs[i].split("\\s+");
                    String courseName = courseInfo[0];
                    Double[] grades = new Double[courseInfo.length - 1];
                    for (int j = 1; j < courseInfo.length; j++) {
                        grades[j - 1] = Double.parseDouble(courseInfo[j]);
                    }

                    Course course = new StudentCourse(courseName);
                    for (Double grade : grades) {
                        course.addGrade(grade);
                    }

                    courses.add(course);
                }

                Learner student = this.findById(id);
                courses.forEach(student::addCourse);

                inputData = bufferedInputStream.readLine();
                // for (Course course : courses) {
                //     student.addCourse(course);
                // }
            }
        } catch (IOException io) {
            //
        }

    }
}
