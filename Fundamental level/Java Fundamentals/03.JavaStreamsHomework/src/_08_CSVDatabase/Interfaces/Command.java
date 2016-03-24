package _08_CSVDatabase.Interfaces;

public interface Command {
    void Execute(String[] commandArgs, Runnable engine);
}
