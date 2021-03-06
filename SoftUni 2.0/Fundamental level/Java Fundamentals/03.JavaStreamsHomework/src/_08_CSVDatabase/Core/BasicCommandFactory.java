package _08_CSVDatabase.Core;

import _08_CSVDatabase.Core.Commands.*;
import _08_CSVDatabase.Interfaces.CommandFactory;
import _08_CSVDatabase.Interfaces.Command;

import java.security.InvalidParameterException;

public class BasicCommandFactory implements CommandFactory {
    public BasicCommandFactory() {
    }

    @Override
    public Command createCommand(String commandName) throws InvalidParameterException{
        Command command;
        switch (commandName){
            case "Search-by-full-name":
                command = new SearchByFullNameCommand();
                break;
            case "Search-by-id":
                command = new SearchByIdCommand();
                break;
            case "Delete-by-id":
                command = new DeleteByIdCommand();
                break;
            case "Update-by-id":
                command = new UpdateByIdCommand();
                break;
            case "Insert-student":
                command = new InsertStudentCommand();
                break;
            case "Insert-grade-by-id":
                command = new InsertGradeByIdCommand();
                break;
            case "End":
                command = new EndCommand();
                break;
            default:
                throw new InvalidParameterException("Command not supported");
        }

        return command;
    }
}
