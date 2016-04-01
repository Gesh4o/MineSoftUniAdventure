import java.util.Scanner;

public class _03_TheHeiganDance {
    private static final Integer CloudDamage =  3500;
    private static final Integer EruptionDamage = 6000;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char[][] grid = new char[15][15];

        Integer playerHealth = 18_500;
        Integer playerPosX = 7;
        Integer playerPosY = 7;
        boolean isCloudDotActive = false;
        double playerDamageOnTurn = Double.parseDouble(scanner.nextLine());
        String lastSpellName ="";

        Double heigenHealth = 3_000_000d;

        String input = scanner.nextLine();
        while (input != null){
            heigenHealth -=  playerDamageOnTurn;

            if (isCloudDotActive){
                playerHealth -= CloudDamage;
                isCloudDotActive = false;
                if (playerHealth <= 0){
                    lastSpellName = "Plague Cloud";
                    break;
                }
            }

            grid[playerPosX][playerPosY] = 'P';

            if (heigenHealth <= 0){
                break;
            }

            String[] commandInfo = input.split("\\s+");
            String spellName = commandInfo[0];
            Integer spellX = Integer.parseInt(commandInfo[1]);
            Integer spellY = Integer.parseInt(commandInfo[2]);

            Integer startRow = Math.max(0, spellX - 1);
            Integer endRow = Math.min(14, spellX + 1);

            Integer startCol = Math.max(0, spellY - 1);
            Integer endCol = Math.min(14, spellY + 1);

            boolean isPlayerInDamageZone = false;
            for (int row = startRow; row <= endRow; row++) {
                for (int col = startCol; col <= endCol; col++) {
                    if (grid[row][col] == 'P'){
                        isPlayerInDamageZone = true;
                    }else{
                        grid[row][col] = 'D';
                    }
                }
            }

            if (isPlayerInDamageZone){
                if (playerPosX - 1 >= 0 && grid[playerPosX - 1][playerPosY] != 'D'){
                    playerPosX--;
                }else if(playerPosY + 1 < 15 && grid[playerPosX][playerPosY + 1] != 'D'){
                    playerPosY++;
                }else if(playerPosX + 1 < 15 && grid[playerPosX + 1][playerPosY] != 'D'){
                    playerPosX++;
                }else if(playerPosY - 1 >= 0 && grid[playerPosX][playerPosY - 1] != 'D'){
                    playerPosY--;
                }else{
                    switch (spellName){
                        case "Cloud":
                            playerHealth -= CloudDamage;
                            isCloudDotActive = true;
                            break;
                        case "Eruption":
                            playerHealth -= EruptionDamage;
                            break;
                        default:
                            break;
                    }

                    if (playerHealth <= 0){
                        if (spellName.equals("Cloud")){
                            lastSpellName = "Plague Cloud";
                        }else{
                            lastSpellName = spellName;
                        }
                        break;
                    }
                }

                for (int row = startRow; row <= endRow; row++) {
                    for (int col = startCol; col <= endCol; col++) {
                        grid[row][col] = '\u0000';
                    }
                }
            }

            input = scanner.nextLine();
        }

        if (heigenHealth <= 0){
            System.out.println("Heigan: Defeated!");
        }else{
            System.out.printf("Heigan: %.2f%n", heigenHealth);
        }

        if (playerHealth <= 0){
            System.out.printf("Player: Killed by %s%n",lastSpellName);
        }else{
            System.out.printf("Player: %d%n",playerHealth);
        }

        System.out.printf("Final position: %d, %d%n", playerPosX, playerPosY);
    }
}
