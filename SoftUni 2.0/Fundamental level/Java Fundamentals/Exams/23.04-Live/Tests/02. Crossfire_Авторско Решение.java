//import java.io.FileWriter;
//import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Crossfire {
	
	//Method for printing the matrix, in the way it was specified in the Output section of the problem definition.
	private static void printMatrix(ArrayList<ArrayList<Integer>> matrix) {
		for (int row = 0; row < matrix.size(); row++) {
			String currentLine = "";
			for (int col = 0; col < matrix.get(row).size(); col++) {
				currentLine += matrix.get(row).get(col) + " ";
			}
			
			//Trimming to remove the last unneeded space.
			System.out.println(currentLine.trim());
		}
	}
	
	//Method for filling the matrix starting from the beginning, with consecutively increasing integers.
	private static ArrayList<ArrayList<Integer>> fillMatrix(Integer rows, Integer cols) {
		
		//Simulated matrix - read the main method comments to find the reason.
		ArrayList<ArrayList<Integer>> numberMatrix = new ArrayList<ArrayList<Integer>>();
		//The consecutively increasing integer (filler)
		Integer count = 1;
		
		for (int row = 0; row < rows; row++) {
			
			//Initializing a new row.
			numberMatrix.add(new ArrayList<Integer>());
			for (int col = 0; col < cols; col++) {
				
				//Adding the current value of the filler to the current row.
				numberMatrix.get(row).add(count);
				count++;
			}
		}
		
		//Returning the filled up matrix.
		return numberMatrix;
	}
	
	//Just some method to parse a split string of integers, which results in an array of strings, to an array of integers.
	//Rule number 1: If something is used many times (automate it)
	private static Integer[] parseArgs(String[] inputArgs){
		Integer[] parsedResults = new Integer[inputArgs.length];
		
		for (int i = 0; i < inputArgs.length; i++) {
			parsedResults[i] = Integer.parseInt(inputArgs[i]);
		}
		
		return parsedResults;
	}
	
	//Filtering the matrix, here is the magic.
	//Using ArrayLists provides us with the removeAll method.
	//The removeAll method however, accepts a List as its parameter.
	//But we need to remove only elements which equal "-1" (read below for the reason), not a whole list.
	//Thats why we make an array, which holds 1 element - "-1", and we make it a list with the Arrays.asList() method.
	//You can just initialize a list and add "-1" to it and it will work perfectly, but this way looked more elegant.
	//Using that method we have now successfully remove all destroyed cells.
	//Below the for loop which checks all rows, we remove from the main matrix, every row which is empty.
	//Like explained in the problem definition, destroying a cell means for that cell to become completely nonexistent.
	//If every cell in a row becomes nonexistent the whole row becomes nonexistent.
	private static void filterMatrix(ArrayList<ArrayList<Integer>> matrix){		
		for (int row = 0; row < matrix.size(); row++) {
			matrix.get(row).removeAll(Arrays.asList((new Integer[] {-1})));
		}
		matrix.removeAll(Arrays.asList(new ArrayList<Integer>()));
	}
	
	//This is a method that checks, for a given row and column, if they are actually in the matrix. It is a boolean method
	//so it will either return TRUE or FALSE.
	private static boolean isInMatrix(Integer currentRow, Integer currentCol, ArrayList<ArrayList<Integer>> numberMatrix){
		return currentRow >= 0 && currentRow < numberMatrix.size() && currentCol >= 0 && currentCol < numberMatrix.get(currentRow).size();
	}
	
	public static void main(String[] args) {
	
		Scanner scanner = new Scanner(System.in);
		String[] dimensions = scanner.nextLine().split(" ");
		//Parsing the dimensions
		Integer[] parsedDimensions = parseArgs(dimensions);
		
		//Creating a simulated matrix.
		//We have a matrix, but we need to destroy completely elements from it.
		//An array has a fixed size after its initialization, that is why a list is better for the current case
		//because it supports the removal of elements.
		//After we have declared the matrix, we initialize it with the fillMatrix() method.
		ArrayList<ArrayList<Integer>> numberMatrix = fillMatrix(parsedDimensions[0], parsedDimensions[1]);
		
		//Here we accept the first command arguments.
		String[] commandArgs = scanner.nextLine().split(" ");
		
		//Here we check the ending condition.
		while(!String.join(" ", commandArgs).equals("Nuke it from orbit")){
			
			//Here we parse the command arguments to integers.
			Integer[] parsedArgs = parseArgs(commandArgs);
			//Getting the shotRow
			Integer shotRow = parsedArgs[0];
			//Getting the shotColumn
			Integer shotCol = parsedArgs[1];
			//Getting the shotRadius
			Integer shotRadius = parsedArgs[2];
			
			//Starting from the shotRow - shotRadius which is the top edge of the cross-like figure,
			for (Integer currentRow = shotRow - shotRadius; currentRow <= shotRow + shotRadius; currentRow++) {
				//Only if both coordinates are in the matrix, we shoot at it.
				if(isInMatrix(currentRow, shotCol, numberMatrix)){
					//Once we have found a valid point, a point in the matrix, we mark it as "-1", because all integers are > 0
					//Using that advantage we could mark a cell with -1 and it will not conflict with any other cell,
					//because all others have unique values above zero.
					numberMatrix.get(currentRow).set(shotCol, -1);
				}
			}
			
			//Doing the same from above but for the columns now.
			//We start from the left-most column to the right-most.
			for (Integer currentCol = shotCol - shotRadius; currentCol <= shotCol + shotRadius; currentCol++) {
				//The same cell-validation check.
				if(isInMatrix(shotRow, currentCol, numberMatrix)){
					//The same cell-marking operation.
					numberMatrix.get(shotRow).set(currentCol, -1);
				}
			}
			
			//Filtering the matrix, removing all marked cells, and if there after the removal of marked(shot) cells,
			//there is an empty row, we remove it too.
			filterMatrix(numberMatrix);
			//Reading the next arguments.
			commandArgs = scanner.nextLine().split(" ");
		}
		
		//After the main operation of the program has ended, we print the matrix.
		printMatrix(numberMatrix);
	}
}