import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_OfficeStuff {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile("\\|([\\w]+) - ([0-9]+) - ([\\w]+)\\|");

        TreeSet<Company> companies = new TreeSet<>();

        Integer n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            Matcher matcher = pattern.matcher(scanner.nextLine());

            if (matcher.find()) {
                String companyName = matcher.group(1);
                Integer amount = Integer.parseInt(matcher.group(2));
                String productName = matcher.group(3);

                if (!companies.stream().anyMatch(c -> c.name.equals(companyName))) {
                    Company company = new Company(companyName);
                    companies.add(company);
                }

                Company company = companies.stream().filter(c -> c.name.equals(companyName)).findFirst().get();

                if (!company.products.stream().anyMatch(p -> p.name.equals(productName))) {
                    Product product = new Product(productName, amount);
                    company.products.add(product);
                } else {
                    Product product = company.products.stream().filter(p -> p.name.equals(productName)).findFirst().get();
                    product.amount += amount;
                }
            }
        }

        System.out.println(String.join("\n", companies.stream().map(Company::toString).toArray(String[]::new)));
    }
}

class Company implements Comparable<Company> {
    public String name;

    ArrayList<Product> products;

    public Company(String name) {
        this.name = name;
        this.products = new ArrayList<>();
    }

    @Override
    public String toString() {
        String stringView =
                String.format(
                        "%s: %s",
                        this.name,
                        String.join(", ", products.stream().map(Product::toString).toArray(String[]::new)));
        return stringView;
    }

    @Override
    public int compareTo(Company other) {
        int compareResult = this.name.compareTo(other.name);
        return compareResult;
    }
}

class Product {
    public String name;

    public Integer amount;

    public Product(String name, Integer amount) {
        this.name = name;
        this.amount = amount;
    }

    @Override
    public String toString() {
        String stringView = String.format("%s-%d", this.name, this.amount);
        return stringView;
    }
}