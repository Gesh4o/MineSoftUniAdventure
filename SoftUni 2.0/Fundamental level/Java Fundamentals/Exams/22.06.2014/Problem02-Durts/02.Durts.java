import java.util.Scanner;

public class Durts {

	public static void main(String[] args) {
		Scanner sc = new Scanner (System.in);
		int centerX = sc.nextInt();
		int centerY = sc.nextInt();
		int r = sc.nextInt();
		int n = sc.nextInt();
		
		double verticalRectMinX = centerX - (0.5 * r);
		double verticalRectMaxX = centerX + (0.5 * r);
		double verticalRectMinY = centerY - r;
		double verticalRectMaxY = centerY + r;
		
		double horizontalRectMinX = centerX - r;
		double horizontalRectMaxX = centerX + r;
		double horizontalRectMinY = centerY - (0.5*r);
		double horizontalRectMaxY = centerY + (0.5*r);
		
		for (int i = 0; i < n; i++) {
			int x = sc.nextInt();
			int y = sc.nextInt();
			boolean inside = 
				isPointInRectangle(
						x, y, 
						verticalRectMinX, verticalRectMaxX, 
						verticalRectMinY, verticalRectMaxY) ||
				isPointInRectangle(
						x, y, 
						horizontalRectMinX, horizontalRectMaxX, 
						horizontalRectMinY, horizontalRectMaxY);
			System.out.println(inside ? "yes" : "no");			
		}
	}

	private static boolean isPointInRectangle(int x, int y,
			double minX, double maxX, double minY, double maxY) {
		boolean inside = (x >= minX) && (x <= maxX) && (y >= minY) && (y <= maxY);
		return inside;
	}

}
