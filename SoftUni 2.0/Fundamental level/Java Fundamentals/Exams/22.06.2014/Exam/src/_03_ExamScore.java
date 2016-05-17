import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_ExamScore {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);
        String command = scanner.nextLine();

        ArrayList<Score> scores = new ArrayList<>();
        int count = 0;
        Pattern pattern = Pattern.compile("\\| ([a-zA-Z]+\\s*[a-zA-Z]+)\\s+\\| ([0-9]+)\\s+\\| ([0-9]\\.[0-9]{2})");
        while (true) {
            if (command.equals("--------------------------------------------") || command.equals("----------------------------------------")){
                count++;
                if (count == 3){
                    break;
                }
                command = scanner.nextLine();
                continue;
            }



            Matcher matcher = pattern.matcher(command);

            if (matcher.find()) {
                String name = matcher.group(1);
                Integer examScore = Integer.parseInt(matcher.group(2));
                Double grade = Double.parseDouble(matcher.group(3));

                if (!scores.stream().anyMatch(s-> s.value.equals(examScore))){
                    Score score = new Score(examScore);
                    scores.add(score);
                }

                Score score = scores.stream().filter(s -> s.value.equals(examScore)).findFirst().get();

                if (!score.students.stream().anyMatch(st -> st.name.equals(name))){
                    Student student = new Student(name);
                    score.students.add(student);
                }

                Student student = score.students.stream().filter(st -> st.name.equals(name)).findFirst().get();

                student.grade = grade;
            }

            command = scanner.nextLine();
        }
        scores.sort((s1,s2) -> s1.value.compareTo(s2.value));

        for (Score score : scores) {
            System.out.println(score.toString());
        }
    }
}

class Score {
    public Score(Integer value) {
        this.value = value;
        this.students = new TreeSet<>();
    }

    public Integer value;

    public TreeSet<Student> students;

    public Double averageGrade() {
        Double allGrades = 0.d;
        for (Student student : students) {
            allGrades += student.grade;
        }

        Double result = (allGrades * 1.0) / this.students.size();
        return result;
    }

    @Override
    public String toString() {
        // 0 -> [Ivan Ivanov]; avg=2.0
        String stringView = String.format("%d -> %s; avg=%.2f", this.value, this.students.toString(), this.averageGrade());

        return stringView;
    }
}

class Student implements Comparable<Student> {
    public Student(String name) {
        this.name = name;
    }

    public String name;

    public Double grade;

    @Override
    public int compareTo(Student o) {
        return this.name.compareTo(o.name);
    }

    @Override
    public String toString() {
        return this.name;
    }
}