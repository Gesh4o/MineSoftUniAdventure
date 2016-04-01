import java.text.SimpleDateFormat;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_Events {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer eventsCount = Integer.parseInt(scanner.nextLine());

        TreeSet<Town> towns = new TreeSet<>();
        for (int i = 0; i < eventsCount; i++) {
            String inputData = scanner.nextLine();
            Matcher matcher = Pattern.compile("^#([a-zA-Z]+):[\\s]*@([a-zA-Z]+)[\\s]*([0-9]{1,2}):([0-9]{1,2})$").matcher(inputData);
            if (matcher.find()){
                String personName = matcher.group(1);
                String townName = matcher.group(2);
                Integer hours = Integer.parseInt(matcher.group(3));
                Integer minutes = Integer.parseInt(matcher.group(4));
                if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59){
                    continue;
                }

                Town currentTown;
                if (!towns.stream().anyMatch(t->t.name.equals(townName))){
                    currentTown = new Town(townName);
                    towns.add(currentTown);
                }

                currentTown = towns.stream().filter(t -> t.name.equals(townName)).findFirst().get();

                Person person;
                if (!currentTown.performers.stream().anyMatch(p -> p.name.equals(personName))){
                    person = new Person(personName);
                    currentTown.performers.add(person);
                }

                person = currentTown.performers.stream().filter(p -> p.name.equals(personName)).findFirst().get();

                Calendar calendar = Calendar.getInstance();

                calendar.set(0,Calendar.JANUARY,1,hours,minutes,0);

                Date currentDate = calendar.getTime();

                person.eventsDateTime.add(currentDate);
            }
        }

        String[] wantedCities = scanner.nextLine().split(",+");
        wantedCities = Arrays.stream(wantedCities).sorted().toArray(String[]::new);
        for (int i = 0; i < wantedCities.length; i++) {
            String currentCity = wantedCities[i];
            if (towns.stream().anyMatch(t -> t.name.equals(currentCity))){
                System.out.println(towns.stream().filter(t-> t.name.equals(currentCity)).findFirst().get().toString());
            }
        }
    }
}

class Town implements Comparable<Town>{
    public String name;
    public TreeSet<Person> performers;

    public Town(String name) {
        this.name = name;
        this.performers = new TreeSet<>();
    }

    @Override
    public int compareTo(Town o) {
        return this.name.compareTo(o.name);
    }

    @Override
    public String toString() {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append(String.format("%s:%n",this.name));
        Integer counter = 1;
        for (Person performer : performers) {
            stringBuilder.append(String.format("%d. %s%n", counter, performer.toString()));
            counter++;
        }

        return stringBuilder.toString().trim();
    }
}

class Person implements Comparable<Person>{
    public String name;
    public ArrayList<Date> eventsDateTime;

    public Person(String name) {
        this.name = name;
        this.eventsDateTime = new ArrayList<>();
    }

    @Override
    public int compareTo(Person o) {
        return this.name.compareTo(o.name);
    }

    @Override
    public String toString() {
        String result = String.format("%s -> ",this.name);
        Collections.sort(this.eventsDateTime);
        SimpleDateFormat dt = new SimpleDateFormat("HH:mm");
        String[] dates = this.eventsDateTime.stream().map(dt::format).toArray(String[]::new);
        String datesAsString = String.join(", ", dates);
        result = result + datesAsString;
        return result;
    }
}
