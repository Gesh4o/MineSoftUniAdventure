package _08_CSVDatabase.IO;

import _08_CSVDatabase.Interfaces.InputHandler;

import java.util.Scanner;

public class ConsoleInputHandler implements InputHandler {

    @Override
    public String readLine() {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextLine();
    }
}
