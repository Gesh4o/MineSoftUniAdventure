import java.util.*;

public class _04_DragonArmy {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        LinkedHashMap<String, TreeSet<Dragon>> dragonsByType = new LinkedHashMap<>();

        Integer linesNumber = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < linesNumber; i++) {
            String[] dragonInformation = scanner.nextLine().split("\\s+");
            String dragonType = dragonInformation[0];
            String dragonName = dragonInformation[1];
            String dragonHealthAsString = dragonInformation[3];
            String dragonDamageAsString = dragonInformation[2];
            String dragonArmorAsString = dragonInformation[4];
            Integer dragonHealth = 250;
            Integer dragonDamage = 45;
            Integer dragonArmour = 10;
            boolean isHealthGiven = integerTryParse(dragonHealthAsString);
            boolean isDamageGiven = integerTryParse(dragonDamageAsString);
            boolean isArmorGiven = integerTryParse(dragonArmorAsString);
            if (isHealthGiven){
                dragonHealth = Integer.parseInt(dragonHealthAsString);
            }
            if (isDamageGiven){
                dragonDamage = Integer.parseInt(dragonDamageAsString);
            }
            if (isArmorGiven){
                dragonArmour = Integer.parseInt(dragonArmorAsString);
            }

            Dragon dragon = new Dragon(dragonName,dragonType,dragonHealth,dragonDamage, dragonArmour);

            if (!dragonsByType.containsKey(dragonType)){
                dragonsByType.put(dragonType, new TreeSet<>());
            }

            if (dragonsByType.get(dragonType).contains(dragon)){
                Dragon drag = dragonsByType.get(dragonType).stream().filter(d -> d.equals(dragon)).findFirst().get();
                dragonsByType.get(dragonType).remove(drag);
            }

            dragonsByType.get(dragonType).add(dragon);
        }

        for (Map.Entry<String, TreeSet<Dragon>> dragonEntrySet : dragonsByType.entrySet()) {
            Double averageHp = 0.0d;
            Double averageDamage = 0.0d;
            Double averageArmour = 0.0d;
            for (Dragon drake : dragonEntrySet.getValue()) {
                averageHp += drake.getHealth();
                averageDamage += drake.getDamage();
                averageArmour += drake.getArmour();
            }

            averageDamage /= dragonEntrySet.getValue().size();
            averageArmour /= dragonEntrySet.getValue().size();
            averageHp /= dragonEntrySet.getValue().size();
            System.out.printf("%s::(%.2f/%.2f/%.2f)%n",dragonEntrySet.getKey(), averageDamage, averageHp, averageArmour);

            for (Dragon drake : dragonEntrySet.getValue()) {
                System.out.println(drake.toString());
            }
        }

    }

    private static boolean integerTryParse(String string) {
        try {
            Integer parsedString = Integer.parseInt(string);
        }catch (Exception e){
            return false;
        }
        return  true;
    }
}

class Dragon implements Comparable<Dragon>{
    private String name;

    private String type;

    private Integer health;

    private Integer damage;

    private Integer armour;

    public Dragon(String name, String type, Integer health, Integer damage, Integer armour) {
        this.name = name;
        this.type = type;
        this.health = health;
        this.damage = damage;
        this.armour = armour;
    }

    @Override
    public boolean equals(Object other) {
        if (other == null || this.getClass() != other.getClass()) {
            return false;
        }

        Dragon dragon = (Dragon) other;
        boolean compareResult = this.getName().equals(dragon.name) && this.getType().equals(dragon.type);

        return compareResult;
    }

    @Override
    public int hashCode() {
        int result = name.hashCode();
        result = 31 * result + type.hashCode();
        return result;
    }

    @Override
    public String toString() {
        // -{Name} -> damage: {damage}, health: {health}, armor: {armor}
        String stringView = String.format(
                "-%s -> damage: %d, health: %d, armor: %d",
                this.getName(),
                this.getDamage(),
                this.getHealth(),
                this.getArmour());
        return stringView;
    }

    public String getName() {
        return this.name;
    }

    public String getType() {
        return this.type;
    }

    public Integer getHealth() {
        return this.health;
    }

    public Integer getDamage() {
        return this.damage;
    }

    public Integer getArmour() {
        return this.armour;
    }

    @Override
    public int compareTo(Dragon other) {
        int compareResult = this.name.compareTo(other.name);

        return compareResult;
    }
}