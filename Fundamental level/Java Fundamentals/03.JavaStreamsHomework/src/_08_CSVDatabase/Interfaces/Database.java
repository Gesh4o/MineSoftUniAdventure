package _08_CSVDatabase.Interfaces;

public interface Database {
    Learner findByName(String name);

    Learner findById(int id);

    String deleteById(int id);

    String updateById(int id);

    String insertStudent(Learner student);

    String insertGradeById(int id, Course grade);
}
