import java.util.Arrays;
import java.util.Scanner;

public class _02_Monopoly {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer[] gridDimensions = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Character[][] grid = new Character[gridDimensions[0]][gridDimensions[1]];

        for (int row = 0; row < gridDimensions[0]; row++) {
            char[] currentRow = scanner.nextLine().toCharArray();
            for (int col = 0; col < gridDimensions[1]; col++) {
                grid[row][col] = currentRow[col];
            }
        }

        int money = 50;
        int hotels = 0;
        int turns = 0;

        for (int row = 0; row < gridDimensions[0]; row++) {
            if (row % 2 == 0){
                for (int col = 0; col < gridDimensions[1]; col++) {
                    if(grid[row][col] == 'H'){
                        hotels++;
                        System.out.printf("Bought a hotel for %d. Total hotels: %d.%n", money, hotels);
                        money = 0;
                    }else if (grid[row][col] == 'S'){
                        int initialMoney = money;
                        Integer moneyToSpend = (row + 1) * (col + 1);
                        money -= moneyToSpend;
                        if (money < 0){
                            money = 0;
                        }
                        System.out.printf("Spent %d money at the shop.%n", initialMoney - money);
                    }else if ( grid[row][col] == 'J'){
                        System.out.printf("Gone to jail at turn %d.%n",turns);
                        turns += 2;
                        money += 2 * (hotels * 10);
                    }

                    turns++;
                    money += hotels * 10;
                }
            }
            else{
                for (int col = gridDimensions[1] - 1; col >= 0; col--) {
                    if(grid[row][col] == 'H'){
                        hotels++;
                        System.out.printf("Bought a hotel for %d. Total hotels: %d.%n", money, hotels);
                        money = 0;
                    }else if (grid[row][col] == 'S'){
                        int initialMoney = money;
                        Integer moneyToSpend = (row + 1) * (col + 1);
                        money -= moneyToSpend;
                        if (money < 0){
                            money = 0;
                        }
                        System.out.printf("Spent %d money at the shop.%n", initialMoney - money);
                    }else if ( grid[row][col] == 'J'){
                        System.out.printf("Gone to jail at turn %d.%n",turns);
                        turns += 2;
                        money += 2 * (hotels * 10);
                    }

                    turns++;
                    money += hotels * 10;
                }
            }

        }

        System.out.printf("Turns %d%nMoney %d%n", turns, money);
    }
}
