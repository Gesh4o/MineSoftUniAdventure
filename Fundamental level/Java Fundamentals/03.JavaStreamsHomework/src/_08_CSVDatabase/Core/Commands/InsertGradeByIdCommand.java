package _08_CSVDatabase.Core.Commands;

import _08_CSVDatabase.Interfaces.Command;
import _08_CSVDatabase.Interfaces.Course;
import _08_CSVDatabase.Interfaces.Runnable;
import _08_CSVDatabase.Models.StudentCourse;

public class InsertGradeByIdCommand implements Command {
    @Override
    public void Execute(String[] commandArgs, Runnable engine) {
        Integer id = Integer.parseInt(commandArgs[1]);
        String courseName = commandArgs[2];
        Double gradeValue = Double.parseDouble(commandArgs[3]);
        Course grade = new StudentCourse(courseName, gradeValue);

        engine.getStudentDatabase().insertGradeById(id, grade);
    }
}
