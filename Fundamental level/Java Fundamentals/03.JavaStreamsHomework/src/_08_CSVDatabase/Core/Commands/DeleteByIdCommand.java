package _08_CSVDatabase.Core.Commands;

import _08_CSVDatabase.Interfaces.Command;
import _08_CSVDatabase.Interfaces.Runnable;

public class DeleteByIdCommand implements Command {
    @Override
    public void Execute(String[] commandArgs, Runnable engine) {
        Integer id = Integer.parseInt(commandArgs[1]);
        String result = engine.getStudentDatabase().deleteById(id);
        if (result != null){
            engine.getOutputHandler().printLine(result);
        }
    }
}
