import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_UserLogs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String command = scanner.nextLine();
        Pattern pattern = Pattern.compile("(IP=(.*?) message='.*?' user=(.*?))$");
        TreeSet<User> users = new TreeSet<>();

        while (!command.equals("end")){
            Matcher matcher = pattern.matcher(command);
            if (matcher.find()){
                String ipAddressString = matcher.group(2);
                String username = matcher.group(3);

                User user;
                if (users.stream().anyMatch(u -> u.username.equals(username))){
                    user = users.stream().filter(u -> u.username.equals(username)).findFirst().get();
                }else{
                    user = new User(username);
                    users.add(user);
                }

                Ip ip;
                if (user.ip.stream().anyMatch(i -> i.ipAddress.equals(ipAddressString))){
                    ip = user.ip.stream().filter(i -> i.ipAddress.equals(ipAddressString)).findFirst().get();
                    ip.timesUsed++;
                }else{
                    ip = new Ip(ipAddressString);
                    user.ip.add(ip);
                }
            }

            command = scanner.nextLine();
        }


        String[] resultUsers = users.stream().map(User::toString).toArray(String[]::new);

        System.out.println(String.join("\n", resultUsers));
    }
}

class User implements Comparable<User>{
    public User(String username) {
        this.username = username;
        this.ip = new ArrayList<>();
    }

    public String username;

    public ArrayList<Ip> ip;
    
    @Override
    public int compareTo(User other) {
        int compareResult = this.username.compareTo(other.username);

        return compareResult;
    }

    @Override
    public String toString() {
        String ipAsString = String.join(", " ,this.ip.stream().map(Ip::toString).toArray(String[]::new));
        String stringView = String.format("%s:%n%s.", this.username, ipAsString);
        return stringView;
    }
}

class  Ip implements Comparable<Ip>{
    public String ipAddress;

    public Integer timesUsed;

    public Ip(String ipAddress) {
        this.ipAddress = ipAddress;
        this.timesUsed = 1;
    }

    @Override
    public String toString() {
        String stringView = String.format("%s => %d", this.ipAddress, this.timesUsed);
        return stringView;
    }

    @Override
    public int compareTo(Ip o) {
        int compareToResult = o.timesUsed.compareTo(this.timesUsed);
        return compareToResult;
    }
}
