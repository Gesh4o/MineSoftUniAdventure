package _08_CSVDatabase.Core.Commands;

import _08_CSVDatabase.Interfaces.Command;
import _08_CSVDatabase.Interfaces.Learner;
import _08_CSVDatabase.Interfaces.Runnable;
import _08_CSVDatabase.Models.Student;

import java.io.IOException;

public class InsertStudentCommand implements Command {
    @Override
    public void Execute(String[] commandArgs, Runnable engine) throws IOException {
        String firstName = commandArgs[1];
        String lastName = commandArgs[2];
        Integer age = Integer.parseInt(commandArgs[3]);
        String town = commandArgs[4];
        Learner student = new Student(firstName, lastName, age, town);

        engine.getStudentDatabase().insertStudent(student);
    }
}
