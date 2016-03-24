package _08_CSVDatabase.Core.Commands;

import _08_CSVDatabase.Interfaces.Command;
import _08_CSVDatabase.Interfaces.Learner;
import _08_CSVDatabase.Interfaces.Runnable;

public class SearchByIdCommand implements Command {
    @Override
    public void Execute(String[] commandArgs, Runnable engine) {
        Integer id = Integer.parseInt(commandArgs[1]);
        Learner student = engine.getStudentDatabase().findById(id);
        if (student == null){
            engine.getOutputHandler().printLine("Student does not exist!");
        }
        else {
            engine.getOutputHandler().printLine(student.toString());
        }
    }
}
