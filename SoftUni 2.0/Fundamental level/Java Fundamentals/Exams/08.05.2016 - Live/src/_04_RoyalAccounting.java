import java.math.BigDecimal;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_RoyalAccounting {
    private static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        String input = scanner.nextLine();
        List<Team> teams = new ArrayList<>();
        Pattern pattern = Pattern.compile("^([a-zA-Z]+);([0-9\\-]+);([0-9\\.\\-]+);([a-zA-Z]+)$");
        Matcher matcher;

        while (!input.equals("Pishi kuf i da si hodim")) {
            matcher = pattern.matcher(input);
            if (matcher.find()) {
                String employeeName = matcher.group(1);
                Long employeeWorkHours = Long.parseLong(matcher.group(2));
                BigDecimal employeeDailyPayment = new BigDecimal(matcher.group(3));
                String teamName = matcher.group(4);

                if (!teams.stream().anyMatch(t -> t.getEmployees().stream().anyMatch(e -> e.getName().equals(employeeName)))) {
                    if (!teams.stream().anyMatch(t -> t.getName().equals(teamName))) {
                        teams.add(new Team(teamName));
                    }

                    Team team = teams.stream().filter(t -> t.getName().equals(teamName)).findFirst().get();

                    team.addEmployee(new Employee(employeeName, employeeWorkHours, employeeDailyPayment));

                }
            }

            input = scanner.nextLine();
        }

        teams.stream().forEach(t -> t.getEmployees().sort(Employee::compareTo));
        teams.sort(Team::compareTo);

        String[] teamsAsStrings = teams.stream().map(Team::toString).toArray(String[]::new);

        System.out.println(String.join("\n", teamsAsStrings));
    }
}

class Team implements Comparable<Team> {
    public String getName() {
        return name;
    }

    private String name;

    public List<Employee> getEmployees() {
        return employees;
    }

    private List<Employee> employees;

    public Team(String name) {
        this.name = name;
        this.employees = new ArrayList<>();
    }

    public void addEmployee(Employee employee) {
        this.employees.add(employee);
    }

    public BigDecimal getGatheredMoney() {
        BigDecimal monthlyGatheredMoney = BigDecimal.ZERO;

        for (Employee employee : employees) {
            monthlyGatheredMoney = monthlyGatheredMoney.add(employee.getMonthlyIncome());
        }

        return monthlyGatheredMoney;
    }

    @Override
    public String toString() {
        StringBuilder stringView = new StringBuilder();
        stringView.append(String.format("Team - %s%n", this.name));
        for (Employee employee : employees) {
            stringView.append(employee.toString()).append("\n");
        }

        return stringView.toString().trim();
    }

    @Override
    public int compareTo(Team other) {
        int result = other.getGatheredMoney().compareTo(this.getGatheredMoney());

        return result;
    }
}

class Employee implements Comparable<Employee> {
    public String getName() {
        return name;
    }

    private String name;

    private BigDecimal dailyPayment;

    private Long workHours;

    private BigDecimal dailySalary;

    public Employee(String name, Long workHours, BigDecimal dailyPayment) {
        this.name = name;
        this.dailyPayment = dailyPayment;
        this.workHours = workHours;
        this.dailySalary = (this.dailyPayment.multiply(new BigDecimal(this.workHours))).divide(new BigDecimal("24"), 15, BigDecimal.ROUND_FLOOR);
    }

    public BigDecimal getDailySalary() {
        return this.dailySalary;
    }

    public BigDecimal getMonthlyIncome() {
        BigDecimal result = this.getDailySalary().multiply(new BigDecimal("30"));
        return result;
    }

    @Override
    public String toString() {
        StringBuilder stringView = new StringBuilder();
        stringView.append(String.format(
                "$$$%s - %d - %s",
                this.name,
                this.workHours,
                this.dailySalary = this.dailySalary.setScale(6, BigDecimal.ROUND_HALF_UP)));

        return stringView.toString().trim();
    }

    @Override
    public int compareTo(Employee other) {
        int result = other.workHours.compareTo(this.workHours);

        if (result == 0) {
            result = other.getDailySalary().compareTo(this.getDailySalary());
        }

        if (result == 0) {
            result = this.name.compareTo(other.name);
        }

        return result;
    }
}