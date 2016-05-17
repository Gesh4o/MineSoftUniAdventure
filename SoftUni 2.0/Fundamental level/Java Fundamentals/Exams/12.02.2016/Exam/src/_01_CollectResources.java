import java.util.*;

public class _01_CollectResources {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] resourceField = scanner.nextLine().split("\\s+");
        Integer paths = Integer.parseInt(scanner.nextLine());

        Integer maxCollectedResources = 0;
        for (int i = 0; i < paths; i++) {
            Integer[] pathInfo = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
            Integer startIndex = pathInfo[0];
            Integer step = pathInfo[1];

            HashSet<Integer> collectedResourceIndexes = new HashSet<>();
            Integer currentIndex = startIndex;
            Integer currentResourcesCollected = 0;

            while (!collectedResourceIndexes.contains(currentIndex)) {
                String[] resourceInfo = resourceField[currentIndex].split("_+");
                if (resourceInfo[0].equals("wood") || resourceInfo[0].equals("gold") || resourceInfo[0].equals("stone") || resourceInfo[0].equals("food")) {
                    if (resourceInfo.length == 1) {
                        currentResourcesCollected++;
                    } else {
                        Integer resourceQuantity = Integer.parseInt(resourceInfo[1]);
                        currentResourcesCollected += resourceQuantity;
                    }

                    collectedResourceIndexes.add(currentIndex);
                }

                currentIndex += step;
                if (currentIndex >= resourceField.length) {
                    currentIndex = currentIndex % resourceField.length;
                }
            }

            if (currentResourcesCollected > maxCollectedResources) {
                maxCollectedResources = currentResourcesCollected;
            }
        }

        System.out.println(maxCollectedResources);
    }
}
