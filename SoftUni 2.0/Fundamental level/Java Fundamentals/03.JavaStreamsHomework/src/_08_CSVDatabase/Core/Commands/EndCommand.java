package _08_CSVDatabase.Core.Commands;

import _08_CSVDatabase.Interfaces.Command;
import _08_CSVDatabase.Interfaces.Runnable;

public class EndCommand implements Command {
    @Override
    public void Execute(String[] commandArgs, Runnable engine) {
        System.exit(0);
    }
}
