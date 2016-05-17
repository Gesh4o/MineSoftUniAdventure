import java.util.ArrayList;
import java.util.Objects;
import java.util.Scanner;

public class _16_LogsAggregator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer commandsCount = Integer.parseInt(scanner.nextLine());

        ArrayList<User> users = new ArrayList<>();

        for (int i = 0; i < commandsCount; i++) {
            String[] commandInfo = scanner.nextLine().split("\\s+");

            String ip = commandInfo[0];
            String username = commandInfo[1];
            Integer duration = Integer.parseInt(commandInfo[2]);

            if (!users.stream().anyMatch(user -> user.getName().equals(username))){
                users.add(new User(username));
            }

            User currentUser = users.stream().filter(user -> Objects.equals(user.getName(), username)).findFirst().orElse(null);

            currentUser.setDuration(currentUser.getDuration() + duration);

            if (!currentUser.getIpAddresses().contains(ip)){
                currentUser.addIpAddresses(ip);
            }
        }

        users.sort((firstUser, secondUser) -> firstUser.getName().compareTo(secondUser.getName()));

        for (int i = 0; i < users.size(); i++) {
            // users.get(i).getIpAddresses().sort((firstIp, secondIp) -> firstIp.compareTo(secondIp));

            users.get(i).getIpAddresses().sort(String::compareTo);

            System.out.printf(
                    "%s: %d [%s]%n",
                    users.get(i).getName(),
                    users.get(i).getDuration(),
                    String.join(", ", users.get(i).getIpAddresses()));
        }
    }
}

class User{
    private int duration;

    private ArrayList<String> ipAddresses;

    private String name;

    public User(String name) {
        this.name = name;
        this.ipAddresses = new ArrayList<>();
    }

    public String getName() {
        return this.name;
    }

    public int getDuration() {
        return duration;
    }

    public void setDuration(int duration) {
        this.duration = duration;
    }

    public ArrayList<String> getIpAddresses() {
        return ipAddresses;
    }

    public void addIpAddresses(String ip){
        this.ipAddresses.add(ip);
    }
}