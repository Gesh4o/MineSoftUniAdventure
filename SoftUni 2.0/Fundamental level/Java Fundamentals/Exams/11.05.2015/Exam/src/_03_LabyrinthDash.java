import java.util.Scanner;

public class _03_LabyrinthDash {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer n = Integer.parseInt(scanner.nextLine());

        char[][] grid = new char[n][];
        for (int row = 0; row < n ; row++) {
            grid[row] = scanner.nextLine().toCharArray();
        }

        char[] commandDirections = scanner.nextLine().toCharArray();

        int playerX = 0;
        int playerY = 0;
        int movesMade = 0;
        int lives = 3;

        for (int currentDirectionIndex = 0; currentDirectionIndex < commandDirections.length; currentDirectionIndex++) {

            String commandResult = null;
            Character currentChar = commandDirections[currentDirectionIndex];
            switch (currentChar){
                case '^':
                    if (playerX - 1 < 0 || grid[playerX].length <= playerY || grid[playerX - 1][playerY] == ' '){
                        movesMade++;
                        commandResult = "Fell off a cliff! Game Over!";
                        break;
                    }else if(grid[playerX - 1][playerY] == '|' || grid[playerX - 1][playerY] == '_'){
                        commandResult = "Bumped a wall.";
                        break;
                    }else if(grid[playerX - 1][playerY] == '*' || grid[playerX - 1][playerY] == '@' || grid[playerX - 1][playerY] == '#'){
                        lives--;
                        commandResult = String.format("Ouch! That hurt! Lives left: %d",lives);
                        if (lives == 0){
                            System.out.println(commandResult);
                            movesMade++;
                            commandResult = "No lives left! Game Over!";
                            break;
                        }
                    }else if(grid[playerX - 1][playerY] == '$'){
                        lives++;
                        commandResult = String.format("Awesome! Lives left: %d",lives);
                        grid[playerX - 1][playerY] = '.';

                    }else{
                        commandResult = "Made a move!";
                    }

                    if (!commandResult.equals("Bumped a wall.")){
                        playerX--;
                        movesMade++;
                    }
                    break;
                case '>':
                    if (playerY + 1 >= grid[playerX].length || grid[playerX][playerY + 1] == ' '){
                        movesMade++;
                        commandResult = "Fell off a cliff! Game Over!";
                        break;
                    }else if(grid[playerX][playerY + 1] == '|' || grid[playerX][playerY + 1] == '_'){
                        commandResult = "Bumped a wall.";
                        break;
                    }else if(grid[playerX][playerY + 1] == '*' || grid[playerX][playerY + 1] == '@' || grid[playerX][playerY + 1] == '#'){
                        lives--;
                        commandResult = String.format("Ouch! That hurt! Lives left: %d",lives);
                        if (lives == 0){
                            System.out.println(commandResult);
                            commandResult = "No lives left! Game Over!";
                            movesMade++;
                            break;
                        }
                    }else if(grid[playerX][playerY + 1] == '$'){
                        lives++;
                        commandResult = String.format("Awesome! Lives left: %d",lives);
                        grid[playerX][playerY + 1] = '.';

                    }else{
                        commandResult = "Made a move!";
                    }

                    if (!commandResult.equals("Bumped a wall.")){
                        playerY++;
                        movesMade++;
                    }
                    break;
                case '<':
                    if (playerY - 1 <= -1 || grid[playerX][playerY - 1] == ' '){
                        movesMade++;
                        commandResult = "Fell off a cliff! Game Over!";
                        break;
                    }else if(grid[playerX][playerY - 1] == '|' || grid[playerX][playerY - 1] == '_'){
                        commandResult = "Bumped a wall.";
                        break;
                    }else if(grid[playerX][playerY - 1] == '*' || grid[playerX][playerY - 1] == '@' || grid[playerX][playerY - 1] == '#'){
                        lives--;
                        commandResult = String.format("Ouch! That hurt! Lives left: %d",lives);

                        if (lives == 0){
                            System.out.println(commandResult);
                            commandResult = "No lives left! Game Over!";
                            movesMade++;
                            break;
                        }
                    }else if(grid[playerX][playerY - 1] == '$'){
                        lives++;
                        commandResult = String.format("Awesome! Lives left: %d",lives);
                        grid[playerX][playerY - 1] = '.';
                    }else{
                        commandResult = "Made a move!";
                    }

                    if (!commandResult.equals("Bumped a wall.")){
                        playerY--;
                        movesMade++;
                    }
                    break;
                case 'v':
                    if (playerX + 1 >= grid.length || grid[playerX + 1].length <= playerY || grid[playerX + 1][playerY] == ' '){
                        movesMade++;
                        commandResult = "Fell off a cliff! Game Over!";
                        break;
                    }else if(grid[playerX + 1][playerY] == '|' || grid[playerX + 1][playerY] == '_'){
                        commandResult = "Bumped a wall.";
                        break;
                    }else if(grid[playerX + 1][playerY] == '*' || grid[playerX + 1][playerY] == '@' || grid[playerX + 1][playerY] == '#'){
                        lives--;
                        commandResult = String.format("Ouch! That hurt! Lives left: %d",lives);
                        if (lives == 0){
                            System.out.println(commandResult);
                            commandResult = "No lives left! Game Over!";
                            movesMade++;
                            break;
                        }

                    }else if(grid[playerX + 1][playerY] == '$'){
                        lives++;
                        commandResult = String.format("Awesome! Lives left: %d",lives);
                        grid[playerX + 1][playerY] = '.';
                    } else{
                        commandResult = "Made a move!";
                    }

                    if (!commandResult.equals("Bumped a wall.")){
                        playerX++;
                        movesMade++;
                    }
                    break;
                default:
                    break;
            }

            System.out.println(commandResult);
            if (commandResult.endsWith("Over!")){
                break;
            }

        }

        System.out.printf("Total moves made: %d", movesMade);
    }
}
