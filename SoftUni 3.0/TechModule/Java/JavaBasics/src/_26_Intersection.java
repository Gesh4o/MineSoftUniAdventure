import java.util.Arrays;
import java.util.Scanner;

public class _26_Intersection {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer[] firstCircleInfo = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Circle firstCircle = new Circle(firstCircleInfo[0], firstCircleInfo[1], firstCircleInfo[2]);

        Integer[] secondCircleInfo = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Circle secondCircle = new Circle(secondCircleInfo[0], secondCircleInfo[1], secondCircleInfo[2]);

        if (Circle.IsIntersecting(firstCircle, secondCircle)) {
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }
}

class Circle {
    public Circle(int x, int y, int radius) {
        this.X = x;
        this.Y = y;
        this.Radius = radius;
    }

    public int X;

    public int Y;

    public int Radius;

    static Boolean IsIntersecting(Circle firstCircle, Circle secondCircle) {
        int distanceBetweenCentersX = Math.abs(firstCircle.X - secondCircle.X);
        int distanceBetweenCentersY = Math.abs(firstCircle.Y - secondCircle.Y);

        int radiusSum = firstCircle.Radius + secondCircle.Radius;

        Boolean isIntersecting = radiusSum >= distanceBetweenCentersX && radiusSum >= distanceBetweenCentersY;

        return isIntersecting;
    }
}
