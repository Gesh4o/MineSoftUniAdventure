package _08_CSVDatabase.Interfaces;

import java.io.IOException;

public interface Database {
    Learner findByName(String name);

    Learner findById(int id);

    String deleteById(int id) throws IOException;

    String updateById(int id) throws IOException;

    String insertStudent(Learner student) throws IOException;

    String insertGradeById(int id, Course grade);
}
