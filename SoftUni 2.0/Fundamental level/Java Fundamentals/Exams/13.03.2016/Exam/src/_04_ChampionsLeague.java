import java.util.*;

public class _04_ChampionsLeague {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String inputData = scanner.nextLine();
        List<Team> championsLeague = new ArrayList<>();
        while (!inputData.equals("stop")){
            String[] inputArgs =  inputData.split("\\|+");
            String firstTeamName = inputArgs[0].trim();
            String secondTeamName = inputArgs[1].trim();

            if (!championsLeague.stream().anyMatch(t -> t.name.equals(firstTeamName))){
                championsLeague.add(new Team(firstTeamName));
            }
            if (!championsLeague.stream().anyMatch(t -> t.name.equals(secondTeamName))){
                championsLeague.add(new Team(secondTeamName));
            }

            Integer[] firstMatchResult = Arrays.stream(inputArgs[2].trim().split(":+")).map(Integer::parseInt).toArray(Integer[]::new);
            Integer[] secondMatchResult = Arrays.stream(inputArgs[3].trim().split(":+")).map(Integer::parseInt).toArray(Integer[]::new);

            Integer firstTeamGoals = firstMatchResult[0] + secondMatchResult[1];
            Integer secondTeamGoals = firstMatchResult[1] + secondMatchResult[0];

            Team firstTeam = championsLeague.stream().filter( t -> t.name.equals(firstTeamName)).findFirst().get();
            Team secondTeam = championsLeague.stream().filter( t -> t.name.equals(secondTeamName)).findFirst().get();

            if (firstTeamGoals > secondTeamGoals){
                firstTeam.wins++;
            }else if(secondTeamGoals > firstTeamGoals){
                secondTeam.wins++;
            }else if (firstTeamGoals.equals(secondTeamGoals)){
                int firstTeamAwayGoals = secondMatchResult[1];
                int secondTeamAwayGoals = firstMatchResult[1];
                if (firstTeamAwayGoals > secondTeamAwayGoals){
                    firstTeam.wins++;
                }else{
                    secondTeam.wins++;
                }
            }
            firstTeam.opponents.add(secondTeam);
            secondTeam.opponents.add(firstTeam);
            inputData = scanner.nextLine();
        }

        Collections.sort(championsLeague);
        championsLeague.forEach(System.out::println);

    }
}

class Team implements Comparable<Team> {
    public String name;
    public Integer wins;
    public ArrayList<Team> opponents;

    public Team(String name) {
        this.name = name;
        this.wins = 0;
        this.opponents = new ArrayList<>();
    }

    @Override
    public int compareTo(Team o) {
        Integer compare = (-1)*this.wins.compareTo(o.wins);
        if (compare.equals(0)){
            compare = this.name.compareTo(o.name);
        }

        return compare;
    }

    @Override
    public boolean equals(Object other) {
        if (other instanceof Team && ((Team)other).name.equals(this.name)){
            return true;
        }
        return false;
    }

    @Override
    public int hashCode() {
        return name != null ? name.hashCode() : 0;
    }

    @Override
    public String toString() {
        this.opponents.sort((o,o1) -> o.name.compareTo(o1.name));
        String opponents = String.join(", ", this.opponents.stream().map(o-> o.name).toArray(String[]::new));
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append(String.format("%s%n",this.name));
        stringBuilder.append(String.format("- Wins: %d%n",this.wins));
        stringBuilder.append(String.format("- Opponents: %s%n",opponents));

        return stringBuilder.toString().trim();
    }
}
