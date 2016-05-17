import java.util.Arrays;
import java.util.Scanner;

public class _01_SoftUniPalatkaConf {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer mealsCount = 0;
        Integer roomsCount = 0;
        Integer people = Integer.parseInt(scanner.nextLine());
        Integer counter = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < counter; i++) {
            String[] inputInfo = Arrays.stream(scanner.nextLine().split("\\s+")).toArray(String[]::new);
            String supplyName = inputInfo[0];
            Integer supplyCount = Integer.parseInt(inputInfo[1]);
            String supplyType = inputInfo[2];
            switch(supplyName){
                case "tents":
                    if (supplyType.equals("firstClass")){
                        roomsCount += (supplyCount * 3);
                    }else if (supplyType.equals("normal")) {
                        roomsCount += (supplyCount * 2);
                    }
                    break;
                case "rooms":
                    if (supplyType.equals("single")){
                        roomsCount += supplyCount;
                    }else if (supplyType.equals("double")){
                        roomsCount += supplyCount * 2;
                    }else if (supplyType.equals("triple")){
                        roomsCount += supplyCount * 3;
                    }
                    break;
                case "food":
                    if (supplyType.equals("musaka")){
                        mealsCount += supplyCount * 2;
                    }
                    break;
            }
        }

        int bedDiff = Math.abs(roomsCount - people);
        int mealsDiff = Math.abs(mealsCount - people);
        if (roomsCount >= people){
            System.out.printf("Everyone is happy and sleeping well. Beds left: %d%n",bedDiff);
        }else{
            System.out.printf("Some people are freezing cold. Beds needed: %d%n",bedDiff);
        }

        if (mealsCount >= people){
            System.out.printf("Nobody left hungry. Meals left: %d%n",mealsDiff);
        }else{
            System.out.printf("People are starving. Meals needed: %d%n",mealsDiff);
        }

    }
}
