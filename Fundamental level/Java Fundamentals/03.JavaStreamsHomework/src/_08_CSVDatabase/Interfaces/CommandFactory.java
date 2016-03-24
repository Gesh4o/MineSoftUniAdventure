package _08_CSVDatabase.Interfaces;

import java.security.InvalidParameterException;

public interface CommandFactory{
    Command createCommand(String commandName) throws InvalidParameterException;
}
