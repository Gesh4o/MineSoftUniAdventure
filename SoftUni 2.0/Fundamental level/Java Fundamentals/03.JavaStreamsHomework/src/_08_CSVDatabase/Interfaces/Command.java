package _08_CSVDatabase.Interfaces;

import java.io.IOException;

public interface Command {
    void Execute(String[] commandArgs, Runnable engine) throws IOException;
}
