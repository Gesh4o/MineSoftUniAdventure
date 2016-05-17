import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class CriticalBreakpoint {
	
	//Some method for parsing split string, which results in a string array, to integer array.
	private static Integer[] parseArgs(String[] inputArgs) {

		Integer[] parsedResults = new Integer[inputArgs.length];

		for (int i = 0; i < inputArgs.length; i++) {
			parsedResults[i] = Integer.parseInt(inputArgs[i]);
		}

		return parsedResults;
	}
	
	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		
		//Making a list for all the lines.
		ArrayList<Integer[]> allLines = new ArrayList<>();
		
		//Reading the first inputLine
		String inputLine = scanner.nextLine();
		
		//Ending condition
		while(!inputLine.equals("Break it.")){
			//Parsing the line coordinates from the input line.
			Integer[] inputCoordinates = parseArgs(inputLine.split(" "));
			
			//Initializing the new line.
			Integer[] currentLine = new Integer[4];
			
			//Adding the parsed integers(coordinates) to the line. 
			currentLine[0] = inputCoordinates[0]; //X1
			currentLine[1] = inputCoordinates[1]; //Y1
			currentLine[2] = inputCoordinates[2]; //X2
			currentLine[3] = inputCoordinates[3]; //Y2
			
			//Adding the new line to the list with lines.
			allLines.add(currentLine);
			
			//Reading the next line.
			inputLine = scanner.nextLine();
		}
		
		//Boolean for breakpoint, if we have found it, initialy set to true.
		Boolean hasFoundBreakpoint = true;
		
		//Getting the first ratio, because if it is not zero it will become the actual value, according to the problem definition.
		//It is of Long type because the Constraints section in the problem definition specify that the coordinates can be:
		//[Integer minimal value to Integer maximum value]
		//worst case - (Integer maximum value + Integer maximum value) - (0 + 0) = 2 * Integer maximum value,
		//which exceeds the boundaries of Integer.
		//Math.abs to get the absolute value of the expression inside it.
		//Cast to long is needed, as specified above (Integer maximum value + Integer maximum value) exceeds the boundaries of Integer
		//and that will cause bad values, for that we need to be sure that the addition is of a bigger type.
		Long neededRatio = Math.abs(((long)allLines.get(0)[3] + (long)allLines.get(0)[2]) - ((long)allLines.get(0)[1] + (long)allLines.get(0)[0]));
		
		//Getting all other lines' critical ratios.
		for (int i = 1; i < allLines.size(); i++) {
			
			//Getting the current line.
			Integer[] currentLine = allLines.get(i);
			
			//Getting the current ratio.
			Long currentLineCriticalRatio = Math.abs(((long)currentLine[3] + (long)currentLine[2]) - ((long)currentLine[1] + (long)currentLine[0])); 
			
			//If the previous ratio was zero, we set it to the new ratio.
			//With this check we attempt to find the non-zero value which is the actual value.
			if(neededRatio == 0){
				neededRatio = currentLineCriticalRatio;
			}
			
			//If the current critical ratio does not equal the actual value, and is not equal to zero
			//(0L because we compare Long types)
			//If the check succeeds that means that the current lines do not form a critical breakpoint,
			//we set hasFoundBreakpoint to false and break the loop.
			//We use equals because we use Long(class) instead of long(wrapper) and in Java the "==" operator,
			//compares classes by reference, not by value. Same case as why we dont use "==" for Strings in Java.
			if(!currentLineCriticalRatio.equals(neededRatio) && !currentLineCriticalRatio.equals(0L)){
				hasFoundBreakpoint = false;
				break;
			}
		}
		
		//After we have finished the calculation of critical ratios we check if there is a breakpoint.
		//It will only remain true, if all the critical ratios meet the, specified in the problem definition, condition.
		if(hasFoundBreakpoint){
			//Printing all the lines as specified in the Output section of the problem definition.
			for (Integer[] line : allLines) {
				System.out.println(String.format("Line: %s", Arrays.asList(line)));
			}
			
			//Constraints section of the problem definition says that the coordinates might be Integer max value.
			//That means that the ratio might exceed Integer max value, which is why we made it long.
			//However we are powering numbers now, which means that we might power Integer max value to a very big power
			//Example: Integer max value is 2 000 000 000, which powered by 3 is: 2 000 000 000 * 2 000 000 000 * 2 000 000 000
			//That exceeds even Long boundaries, which means we must use a bigger type (BigInteger), same as C#'s BigInteger.
			//We make a BigInteger with the ratio's value.
			BigInteger result = new BigInteger(neededRatio.toString());
			
			//We use the BigInteger's pow(Power) method because if we use Math.pow that returns double values
			//And double values might not be correct in some very big cases.
			result = result.pow(allLines.size());
			
			//We get the divisor, which is allLines.size(), but that returns int, so we need to make it Integer.
			//Thats why we use Integer.valueOf() method, so we can then use toString().
			//Because BigInteger takes string as parameters.
			BigInteger divisor = new BigInteger(Integer.valueOf(allLines.size()).toString());
			
			//Then we use the BigInteger's built-in method for division with remainder.
			BigInteger criticalBreakpoint = result.remainder(divisor);
			
			//And we print the critical breakpoint.
			System.out.println(String.format("Critical Breakpoint: %s", criticalBreakpoint));
		}
		else {
			//In case of no breakpoint we print this:
			System.out.println("Critical breakpoint does not exist.");
		}
	}
}
