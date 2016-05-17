import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class GUnit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line;
        String regex = "^([A-Z]\\w+)\\s\\|\\s([A-Z]\\w+)\\s\\|\\s([A-Z]\\w+)$";

        //LinkedHashMap<String, TreeMap<String, List<String>>> classes = new LinkedHashMap<>();
        //List<String> classNames = new ArrayList<>();

        List<Class> classes = new ArrayList<>();



        while (!((line = scanner.nextLine()).equals("It's testing time!"))) {
            Pattern pattern = Pattern.compile(regex);
            Matcher matcher = pattern.matcher(line);

            String currentClass;
            String currentMethod;
            String currentTest;

            boolean noClass = true;
            boolean noMethod = true;
            boolean noTest = true;
            Class existingClass = null;
            Method existingMethod = null;

            if (matcher.find()) {
                currentClass = matcher.group(1);
                currentMethod = matcher.group(2);
                currentTest = matcher.group(3);
            }else {
                continue;
            }

            for (int i = 0; i < classes.size(); i++) {
                Class current = classes.get(i);
                if(current.name.equals(currentClass)){
                    noClass = false;
                    existingClass = current;
                    for (int j = 0; j < current.methods.size(); j++) {
                        Method curr = current.methods.get(j);
                        if (curr.name.equals(currentMethod)) {
                            noMethod = false;
                            existingMethod = curr;
                            if (curr.tests.contains(currentTest)) noTest = false;
                        }
                    }
                }
            }


            if (noClass) {
                Class theClass = new Class(currentClass);
                Method method = new Method(currentMethod);
                method.tests.add(currentTest);
                theClass.methods.add(method);
                classes.add(theClass);
            }else {
                if (noMethod) {
                    Method newMethod = new Method(currentMethod);
                    newMethod.tests.add(currentTest);
                    //classes.remove(existingClass);
                    existingClass.methods.add(newMethod);
                    //classes.add(existingClass);
                }else {
                    if (noTest) {
                        existingMethod.tests.add(currentTest);
                    }
                }
            }


        }

        classes.sort((a, b) -> {
            if (a.getTotalTests() == b.getTotalTests()) {
                if (a.methods.size() == b.methods.size()) {
                    return a.name.compareTo(b.name);
                }else {
                    return a.methods.size() - b.methods.size();
                }
            }else {
                return b.getTotalTests() - a.getTotalTests();
            }
        });

        for (Class aClass : classes) {
            System.out.println(aClass.name + ":");
            aClass.sortMethods();
            for (Method method : aClass.methods) {
                System.out.println("##" + method.name);
                method.sortTests();
                for (String test : method.tests) {
                    System.out.println("####" + test);
                }
            }
        }
    }
}

class Class {
    String name;
    List<Method> methods = new ArrayList<>();

    public Class(String name) {
        this.name = name;
    }

    public int getTotalTests() {
        int sum = 0;
        for (int i = 0; i < this.methods.size(); i++) {
            sum += methods.get(i).tests.size();
        }
        return sum;
    }

    public void sortMethods() {
        this.methods.sort((a, b) -> {
            if (a.tests.size() == b.tests.size()) {
                return a.name.compareTo(b.name);
            }else {
                return b.tests.size() - a.tests.size();
            }
        });
    }
}

class Method {
    String name;
    List<String> tests = new ArrayList<>();

    public Method(String name) {

        this.name = name;
    }

    public void sortTests() {
        this.tests.sort((a, b) -> {
            if (a.length() == b.length()) {
                return a.compareTo(b);
            }else {
                return a.length() - b.length();
            }
        });
    }
}
