import java.time.temporal.Temporal;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_GUnit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Pattern pattern = Pattern.compile(
                "^(([A-Z][a-zA-Z0-9]{2,})\\s\\|\\s([A-Z][a-zA-Z0-9]{2,})\\s\\|\\s([A-Z][a-zA-Z0-9]{2,}))$");
        Matcher matcher;
        ArrayList<TestClass> testClasses = new ArrayList<>();
        String command = scanner.nextLine();
        while (!command.equals("It's testing time!")) {
            matcher = pattern.matcher(command);

            if (matcher.find()) {
                String className = matcher.group(2);
                String methodName = matcher.group(3);
                String testName = matcher.group(4);

                TestClass testClass;
                if (!testClasses.stream().anyMatch(c -> c.name.equals(className))) {
                    testClass = new TestClass(className);
                    testClasses.add(testClass);
                }

                testClass = testClasses.stream().filter(c -> c.name.equals(className)).findFirst().get();

                TestMethod testMethod;
                if (!testClass.testMethods.stream().anyMatch( t -> t.name.equals(methodName))){
                    testMethod = new TestMethod(methodName);
                    testClass.testMethods.add(testMethod);
                }

                testMethod = testClass.testMethods.stream().filter(t -> t.name.equals(methodName)).findFirst().get();

                if (!testMethod.tests.stream().anyMatch( t -> t.name.equals(testName))){
                    testMethod.tests.add(new Test(testName));
                }
            }

            command = scanner.nextLine();
        }

        testClasses.sort(TestClass::compareTo);
        testClasses.stream().forEach( c -> c.testMethods.sort(TestMethod::compareTo));
        String[] tests = testClasses.stream().map(TestClass::toString).toArray(String[]::new);

        System.out.println(String.join("\n", tests));
    }
}

class TestClass implements Comparable<TestClass> {
    String name;
    ArrayList<TestMethod> testMethods;

    public TestClass(String name) {
        this.name = name;
        this.testMethods = new ArrayList<>();
    }

    @Override
    public int compareTo(TestClass other) {
        Integer otherTestClassTestsCount = 0;
        for (TestMethod testMethod : other.testMethods) {
            otherTestClassTestsCount += testMethod.getTests().size();
        }

        Integer thisTestClassTestsCount = 0;
        for (TestMethod testMethod : this.testMethods) {
            thisTestClassTestsCount += testMethod.getTests().size();
        }

        int result = otherTestClassTestsCount.compareTo(thisTestClassTestsCount);
        if (result == 0) {
            result = new Integer(this.testMethods.size()).compareTo(other.testMethods.size());
        }

        if (result == 0) {
            result = this.name.compareTo(other.name);
        }

        return result;
    }

    @Override
    public String toString() {
        StringBuilder stringView = new StringBuilder();
        stringView.append(String.format("%s:%n", this.name));
        for (TestMethod testMethod : testMethods) {
            stringView.append(testMethod).append("\n");
        }

        return stringView.toString().trim();
    }
}

class TestMethod implements Comparable<TestMethod> {
    String name;

    Set<Test> tests;

    public TestMethod(String name) {
        this.name = name;
        this.tests = new TreeSet<>();
    }

    public Set<Test> getTests() {
        return tests;
    }

    @Override
    public int compareTo(TestMethod other) {
        int result = new Integer(other.getTests().size()).compareTo(this.getTests().size());

        if (result == 0) {
            result = this.name.compareTo(other.name);
        }

        return result;
    }

    @Override
    public String toString() {
        StringBuilder stringView = new StringBuilder();
        stringView.append("##").append(this.name).append("\n");
        for (Test test : tests) {
            stringView.append(test.toString());
        }

        return stringView.toString().trim();
    }
}

class Test implements Comparable<Test> {
    public Test(String name) {
        this.name = name;
    }

    String name;

    @Override
    public int compareTo(Test other) {
        int result = new Integer(this.name.length()).compareTo(other.name.length());

        if (result == 0) {
            result = this.name.compareTo(other.name);
        }

        return result;
    }

    @Override
    public String toString() {
        return "####" + this.name + "\n";
    }
}
