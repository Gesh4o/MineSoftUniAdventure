package _08_CSVDatabase.Core;

import _08_CSVDatabase.Interfaces.*;
import _08_CSVDatabase.Interfaces.Runnable;
import com.sun.javaws.exceptions.InvalidArgumentException;

import java.io.IOException;
import java.security.InvalidParameterException;

public class Engine implements Runnable {
    private InputHandler inputHandler;
    private OutputHandler outputHandler;
    private Database studentDatabase;
    private CommandFactory commandFactory;

    public InputHandler getInputHandler() {
        return inputHandler;
    }

    public OutputHandler getOutputHandler() {
        return outputHandler;
    }

    public Database getStudentDatabase() {
        return studentDatabase;
    }

    public CommandFactory getCommandFactory() {
        return commandFactory;
    }

    public Engine(InputHandler inputHandler, OutputHandler outputHandler, Database studentDatabase, CommandFactory commandFactory) {
        this.inputHandler = inputHandler;
        this.outputHandler = outputHandler;
        this.studentDatabase = studentDatabase;
        this.commandFactory = commandFactory;
    }

    @Override
    public void run() {

        while (true) {
            try {
                String commandInput = this.inputHandler.readLine();

                String[] commandArgs = commandInput.split("\\s+");
                String commandName = commandArgs[0];

                Command command = this.commandFactory.createCommand(commandName);
                command.Execute(commandArgs, this);

            } catch (IOException | InvalidParameterException ioe) {
                System.out.println(ioe);
                // Re-throwing the exceptions is not the brightest idea but my logic here is that they can be
                // parsed locally(some info could be added or log that info somewhere) and then give to central
                // exception system which is here.
            }
        }

    }
}
