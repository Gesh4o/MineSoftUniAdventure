import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

public class _04_SchoolSystem {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());

        List<Student> students = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            String[] inputInfo = scanner.nextLine().split("\\s+");
            String fullName = inputInfo[0] + " " + inputInfo[1];
            String subjectName = inputInfo[2];
            Double subjectValue = Double.parseDouble(inputInfo[3]);

            if (!students.stream().anyMatch(s -> s.fullName.equals(fullName))){
                Student student = new Student(fullName);
                students.add(student);
            }

            Student student = students.stream().filter(s -> s.fullName.equals(fullName)).findFirst().get();

            if (!student.subjects.stream().anyMatch(s -> s.subjectName.equals(subjectName))){
                Subject subject = new Subject(subjectName);
                student.subjects.add(subject);
            }

            Subject subject = student.subjects.stream().filter(s -> s.subjectName.equals(subjectName)).findFirst().get();
            subject.grades.add(subjectValue);
        }

        students.sort((s1,s2) -> s1.fullName.compareTo(s2.fullName));

        students.forEach(s -> s.subjects.sort((s1,s2) -> s1.subjectName.compareTo(s2.subjectName)));

        String[] studentInfo = students.stream().map(Student::toString).toArray(String[]::new);

        System.out.println(String.join("\n", studentInfo));
    }
}

class Student{

    public Student(String fullName) {
        this.fullName = fullName;
        this.subjects = new ArrayList<>();
    }

    public String fullName;

    public ArrayList<Subject> subjects;

    @Override
    public String toString() {
        String stringView = String.format("%s: [%s]", this.fullName, String.join(", ", this.subjects.stream().map(Subject::toString).toArray(String[]:: new)));
        return stringView;
    }
}

class Subject{
    public Subject(String subjectName) {
        this.subjectName = subjectName;
        this.grades = new ArrayList<>();
    }

    public String subjectName;

    public ArrayList<Double> grades;

    public Double getAverageGrade(){
        Double sum = 0.0;
        for (Double grade : this.grades) {
            sum+= grade;
        }

        return (sum * 1.0)/ grades.size();
    }

    @Override
    public String toString() {
        String stringView = String.format("%s - %.2f", this.subjectName, this.getAverageGrade());
        return stringView;
    }
}