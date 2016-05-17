package _08_CSVDatabase;

import _08_CSVDatabase.Core.BasicCommandFactory;
import _08_CSVDatabase.Core.Engine;
import _08_CSVDatabase.Core.StudentDatabase;
import _08_CSVDatabase.IO.ConsoleInputHandler;
import _08_CSVDatabase.IO.ConsoleOutputHandler;
import _08_CSVDatabase.Interfaces.CommandFactory;
import _08_CSVDatabase.Interfaces.Database;
import _08_CSVDatabase.Interfaces.InputHandler;
import _08_CSVDatabase.Interfaces.OutputHandler;

import java.util.Locale;

public class CSVDatabaseMain {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        InputHandler inputHandler = new ConsoleInputHandler();
        OutputHandler outputHandler = new ConsoleOutputHandler();
        Database database = new StudentDatabase();
        CommandFactory commandFactory = new BasicCommandFactory();
        Engine engine = new Engine(inputHandler, outputHandler, database, commandFactory);
        engine.run();
    }
}
