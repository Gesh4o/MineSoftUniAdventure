import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_Weightlifting {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        TreeSet<Player> players = new TreeSet<>();
        Integer n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String nextLine = scanner.nextLine();

            Pattern pattern = Pattern.compile("(.*?) (.*?) ([0-9]+) kg");
            Matcher matcher =  pattern.matcher(nextLine);
            if (matcher.find()){
                String playerName = matcher.group(1);
                String exerciseName = matcher.group(2);
                Integer kilos = Integer.parseInt(matcher.group(3));

                Player player;
                if (!players.stream().anyMatch( p-> Objects.equals(p.name, playerName))){
                    player = new Player(playerName);
                    players.add(player);
                }else{
                    player = players.stream().filter(p -> p.name.equals(playerName)).findFirst().get();
                }

                if (!player.exercisesByKilos.stream().anyMatch(e -> e.name.equals(exerciseName))){
                    player.exercisesByKilos.add(new Exercise(exerciseName, (long)kilos));
                }else{
                    Exercise ex = player.exercisesByKilos.stream().filter(e -> e.name.equals(exerciseName)).findFirst().get();
                    ex.kilos += kilos;
                }
            }

        }

        String[] array = players.stream().map(Player::toString).toArray(String[]::new);
        System.out.println(String.join("\n", array));

    }
}

class Player implements Comparable<Player>{
    public String name;

    public TreeSet<Exercise> exercisesByKilos;

    public Player(String name) {
        this.exercisesByKilos = new TreeSet<>();
        this.name = name;
    }

    @Override
    public int compareTo(Player o) {
        return this.name.compareTo(o.name);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%s : ",this.name));
        String[] array = this.exercisesByKilos.stream().map(Exercise::toString).toArray(String[]::new);
        sb.append(String.join(", ", array));

        return  sb.toString();
    }
}

class Exercise implements Comparable<Exercise>{
    public String name;
    public Long kilos;

    public Exercise(String name, Long kilos) {
        this.name = name;
        this.kilos = kilos;
    }

    @Override
    public String toString() {
        return String.format("%s - %d kg", this.name, this.kilos);
    }

    @Override
    public int compareTo(Exercise o) {
        return this.name.compareTo(o.name);
    }
}
