package _08_CSVDatabase.Core.Commands;

import _08_CSVDatabase.Interfaces.Command;
import _08_CSVDatabase.Interfaces.Learner;
import _08_CSVDatabase.Interfaces.Runnable;


public class SearchByFullNameCommand implements Command {
    @Override
    public void Execute(String[] commandArgs, Runnable engine) {
        String fullName = String.format("%s %s", commandArgs[1], commandArgs[2]);
        Learner student = engine.getStudentDatabase().findByName(fullName);
        if (student == null){
            engine.getOutputHandler().printLine("Student does not exist!");
        }
        else {
            engine.getOutputHandler().printLine(student.toString());
        }
    }
}
