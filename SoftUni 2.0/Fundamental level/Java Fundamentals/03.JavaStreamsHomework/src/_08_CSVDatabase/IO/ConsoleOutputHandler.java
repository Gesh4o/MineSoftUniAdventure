package _08_CSVDatabase.IO;

import _08_CSVDatabase.Interfaces.OutputHandler;

public class ConsoleOutputHandler implements OutputHandler {

    @Override
    public void printLine(String message) {
        System.out.println(message);
    }

    @Override
    public void print(String message) {
        System.out.print(message);
    }
}
