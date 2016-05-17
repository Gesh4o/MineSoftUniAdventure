import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeSet;

public class _04_Nuts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());
        TreeSet<Company> companies = new TreeSet<>();
        for (int i = 0; i < n; i++) {
            String[] inputInfo = scanner.nextLine().split("\\s+");

            String companyName = inputInfo[0];
            String nutsType = inputInfo[1];
            Integer kilos = Integer.parseInt(inputInfo[2].replace("kg", ""));

            if (!companies.stream().anyMatch(c -> c.name.equals(companyName))){
                Company company = new Company(companyName);
                companies.add(company);
            }

            Company company = companies.stream().filter(c -> c.name.equals(companyName)).findFirst().get();

            if (!company.nuts.stream().anyMatch(nut -> nut.type.equals(nutsType))){
                Nut nut = new Nut(nutsType);
                company.nuts.add(nut);
            }

            Nut nut = company.nuts.stream().filter( nuts -> nuts.type.equals(nutsType)).findFirst().get();
            nut.kilos += kilos;
        }

        System.out.println(String.join("\n", companies.stream().map(Company::toString).toArray(String[]::new)));
    }
}

class Company implements Comparable<Company>{
    public String name;

    public ArrayList<Nut> nuts;

    public Company(String name) {
        this.name = name;
        this.nuts = new ArrayList<>();
    }

    @Override
    public int compareTo(Company o) {
        return this.name.compareTo(o.name);
    }

    @Override
    public String toString() {
        String stringView = String.format("%s: %s", this.name, String.join(", ",this.nuts.stream().map(Nut::toString).toArray(String[]::new)));
        return stringView;
    }
}

class Nut{
    public String type;

    public Integer kilos;

    public Nut(String type) {
        this.type = type;
        this.kilos = 0;
    }

    @Override
    public String toString() {
        String stringView = String.format("%s-%dkg", this.type, this.kilos);
        return stringView;
    }
}