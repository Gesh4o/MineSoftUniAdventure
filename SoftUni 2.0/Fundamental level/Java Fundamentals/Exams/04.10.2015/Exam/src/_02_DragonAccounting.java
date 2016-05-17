import java.math.BigDecimal;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class _02_DragonAccounting {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        BigDecimal capitalBalance = new BigDecimal(scanner.nextLine());
        List<Employee> employees = new LinkedList<Employee>();

        Pattern simpleEventsPattern = Pattern.compile("((\\d+);(\\d+);([\\d\\.]+);)");
        Pattern additionalEventsPattern = Pattern.compile(
                "[;]?((Machines:([\\d\\.]+))|(Product development:([\\d\\.]+))|Taxes:([\\d\\.]+)|Unconditional funding:([\\d\\.]+)|(Previous years deficit:([\\d\\.]+))[;]?)");
        Matcher matcher;

        int daysPassed = 0;
        String input = scanner.nextLine();
        while (!input.equals("END") && capitalBalance.compareTo(new BigDecimal("0")) > 0) {
            employees = employees.stream().sorted().collect(Collectors.toList());
            matcher = simpleEventsPattern.matcher(input);
            int employeesHired = 0;
            int employeesFired = 0;
            BigDecimal salary = null;
            if (matcher.find()) {
                employeesHired = Integer.parseInt(matcher.group(2));
                employeesFired = Integer.parseInt(matcher.group(3));
                salary = new BigDecimal(matcher.group(4));
            }

            // Hire employees.
            for (int i = 0; i < employeesHired; i++) {
                employees.add(new Employee(salary));
            }

            for (Employee employee : employees) {
                // Pay salaries
                if (daysPassed >= 30 && daysPassed % 30 == 0) {
                    capitalBalance = capitalBalance.subtract(employee.getMonthSalary());
                }
                // Check for a raise.
                employee.checkForARaise();

                // Pass a day.
                employee.work();
            }

            // Fire employees.
            for (int i = 0; i < employeesFired; i++) {
                employees.remove(employees.stream().findFirst().get());
            }

            // Check for additional events.
            input = input.replaceAll(simpleEventsPattern.toString(), "");
            matcher = additionalEventsPattern.matcher(input);
            while (matcher.find()) {
                if (matcher.group(3) != null) {
                    BigDecimal machinesExpenses = new BigDecimal(matcher.group(3));
                    capitalBalance = capitalBalance.subtract(machinesExpenses);
                }
                if (matcher.group(9) != null) {
                    BigDecimal previousYearsDeficit = new BigDecimal(matcher.group(9));
                    capitalBalance = capitalBalance.subtract(previousYearsDeficit);
                }

                if (matcher.group(6) != null) {
                    BigDecimal taxes = new BigDecimal(matcher.group(6));
                    capitalBalance = capitalBalance.subtract(taxes);
                }

                if (matcher.group(5) != null) {
                    BigDecimal productDevelopment = new BigDecimal(matcher.group(5));
                    capitalBalance = capitalBalance.add(productDevelopment);
                }

                if (matcher.group(7) != null) {
                    BigDecimal funding = new BigDecimal(matcher.group(7));
                    capitalBalance = capitalBalance.add(funding);
                }
            }

            daysPassed++;
            input = scanner.nextLine();
        }

        if (capitalBalance.compareTo(new BigDecimal("0")) < 0) {
            System.out.printf("BANKRUPTCY: %.4f%n", capitalBalance.abs());
        } else {
            System.out.printf("%d %s%n", employees.size(), capitalBalance.setScale(4, BigDecimal.ROUND_FLOOR));
        }
    }
}

class Employee implements Comparable<Employee> {
    private Integer totalDaysWorked;

    private Integer daysWorkedInMonth;

    public Employee(BigDecimal salary) {
        this.totalDaysWorked = 0;
        this.daysWorkedInMonth = 0;
        this.salary = salary;
    }

    private BigDecimal salary;

    public void checkForARaise() {
        if (this.totalDaysWorked > 0 && this.totalDaysWorked % 365 == 0) {
            this.salary = this.salary.add(this.salary.multiply(new BigDecimal("0.6")));
        }
    }

    public void work() {
        this.totalDaysWorked++;
        this.daysWorkedInMonth++;
    }

    public BigDecimal getMonthSalary() {
        this.daysWorkedInMonth = 0;
        BigDecimal salary = this.salary.multiply(new BigDecimal(this.daysWorkedInMonth)).divide(new BigDecimal("30"));
        return salary;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Employee)) return false;

        Employee employee = (Employee) o;

        if (!totalDaysWorked.equals(employee.totalDaysWorked)) return false;
        if (!daysWorkedInMonth.equals(employee.daysWorkedInMonth)) return false;
        return salary.equals(employee.salary);

    }

    @Override
    public int hashCode() {
        int result = totalDaysWorked.hashCode();
        result = 31 * result + daysWorkedInMonth.hashCode();
        result = 31 * result + salary.hashCode();
        return result;
    }

    @Override
    public int compareTo(Employee other) {
        return other.totalDaysWorked.compareTo(this.totalDaysWorked);
    }
}