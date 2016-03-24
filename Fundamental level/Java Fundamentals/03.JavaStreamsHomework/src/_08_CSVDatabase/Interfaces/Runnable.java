package _08_CSVDatabase.Interfaces;

public interface Runnable {
    void run();

    InputHandler getInputHandler();

    OutputHandler getOutputHandler();

    Database getStudentDatabase();

    CommandFactory getCommandFactory();
}
