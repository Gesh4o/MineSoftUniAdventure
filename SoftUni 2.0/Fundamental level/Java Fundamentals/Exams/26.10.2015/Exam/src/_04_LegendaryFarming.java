import java.util.ArrayList;
import java.util.Comparator;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_LegendaryFarming {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayList<Material> legendaryMaterials = new ArrayList<>();
        legendaryMaterials.add(new Material("shards", 0));
        legendaryMaterials.add(new Material("fragments", 0));
        legendaryMaterials.add(new Material("motes", 0));
        ArrayList<Material> junkMaterials = new ArrayList<>();

        String input = scanner.nextLine();
        while (true){
            Pattern pattern = Pattern.compile("([0-9]+)[\\s]+(.*?)([\\s]+|$)");

            boolean isEnough = false;
            Matcher matcher = pattern.matcher(input);
            while (matcher.find()){
                String materialName = matcher.group(2).toLowerCase();
                Integer quantity = Integer.parseInt(matcher.group(1).toLowerCase());

                if (materialName.equals("shards") || materialName.equals("motes") || materialName.equals("fragments")){
                    if (legendaryMaterials.stream().anyMatch(m -> m.name.equals(materialName))){
                        legendaryMaterials.stream().filter(m -> m.name.equals(materialName)).findFirst().get().quantity += quantity;
                    }
                }else{
                    if (junkMaterials.stream().anyMatch(m -> m.name.equals(materialName))){
                        junkMaterials.stream().filter(m -> m.name.equals(materialName)).findFirst().get().quantity += quantity;
                    }else{
                        junkMaterials.add(new Material(materialName, quantity));
                    }
                }
                if (legendaryMaterials.stream().anyMatch(m -> m.quantity >= 250)){
                    isEnough =true;
                    break;
                }
            }

            if (isEnough){
                break;
            }

            input = scanner.nextLine();
        }

        Material legendaryMaterial = legendaryMaterials.stream().filter(m-> m.quantity >= 250).findFirst().get();
        legendaryMaterial.quantity -= 250;

        String itemName = "";
        switch (legendaryMaterial.name){
            case "shards":
                itemName = "Shadowmourne";
                break;
            case "fragments":
                itemName = "Valanyr";
                break;
            case "motes":
                itemName = "Dragonwrath";
                break;
        }

        System.out.printf("%s obtained!%n",itemName);

        String[] legendaryMaterialsAsString = legendaryMaterials
                .stream()
                .sorted(new MaterialComparator())
                .map(Material::toString)
                .toArray(String[]::new);

        String[] junkMaterialsAsString = junkMaterials
                .stream()
                .sorted((m1,m2) -> m1.name.compareTo(m2.name))
                .map(Material::toString)
                .toArray(String[]::new);

        System.out.println(String.join("\n",legendaryMaterialsAsString));
        System.out.println(String.join("\n",junkMaterialsAsString));
    }
}

class Material{
    public Material(String name, int quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    public String name;

    public Integer quantity;

    @Override
    public String toString() {
        String stringView = String.format("%s: %d", this.name, this.quantity);
        return stringView;
    }
}

class MaterialComparator implements Comparator<Material>{

    @Override
    public int compare(Material o1, Material o2) {
        int compareResult = o2.quantity.compareTo(o1.quantity);
        if (compareResult == 0){
            compareResult = o1.name.compareTo(o2.name);
        }

        return compareResult;
    }
}