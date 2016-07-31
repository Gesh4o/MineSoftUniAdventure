import java.util.*;

public class _27_AverageGrades {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Student> students = new ArrayList<>();

        int studentsCount = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < studentsCount; i++) {
            String[] studentInfo = Arrays.stream(scanner.nextLine().split("\\s+")).toArray(String[]::new);


            Double[] grades = Arrays.stream(studentInfo).skip(1).map(Double::parseDouble).toArray(Double[]::new);
            students.add(new Student(studentInfo[0], grades));
        }

        Comparator<Student> byName = (e1, e2) -> e1.Name.compareTo(e2.Name);

        Comparator<Student> byGrade = (e1, e2) -> e2.getAvg().compareTo(e1.getAvg());

        for (Student student : students.stream().filter(s -> s.getAvg() >= 5).sorted(byName.thenComparing(byGrade)).toArray(Student[]::new)) {
            System.out.println(student);
        }
    }
}

class Student {
    public Student(String name, Double[] grades) {
        this.Name = name;
        this.Grades = grades;
        OptionalDouble average = Arrays.stream(this.Grades)
                .mapToDouble(a -> a)
                .average();
        this.avgGrades = average.isPresent() ? average.getAsDouble() : 0;
    }

    public String Name;
    public Double[] Grades;
    private Double avgGrades;

    public Double getAvg() {
        return avgGrades;
    }

    @Override
    public String toString() {
        String stringView = String.format("%s -> %.2f", this.Name, this.getAvg());
        return stringView;
    }
}