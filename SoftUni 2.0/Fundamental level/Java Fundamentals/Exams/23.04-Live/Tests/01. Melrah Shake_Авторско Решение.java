import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class MelrahShake {

	//First Google result of search "find occurrences of substring in string"
	//Literally Copy/Paste
	//Finds the count of occurrences of a particular substring in another string
	private static int findOccurrences(String mainString, String subString){
		int lastIndex = 0;
		int count = 0;

		while(lastIndex != -1 && mainString.length() > 0 && subString.length() > 0){

		    lastIndex = mainString.indexOf(subString, lastIndex);

		    if(lastIndex != -1){
		        count++;
		        lastIndex += subString.length();
		    }
		}
		
		return count;
	}
	
	public static void main(String[] args) {
			
		Scanner scanner = new Scanner(System.in);
		
		String inputLine = scanner.nextLine();
		String pattern = scanner.nextLine();
		
		while(true) {
			//The condition:
			//Break if there are less than or 1 occurrence
			//Or if the pattern's length is less than 1 symbol
			if(findOccurrences(inputLine, pattern) <= 1 || pattern.length() < 1){
				System.out.println("No shake.");
				break;			
			}
			
			//Find the first index of the pattern and substrings to it, then substrings after it,
			//resulting in cutting the first match of the pattern from the main string
			//The bottom statement is the same for the last match, using lastIndexOf method.
			inputLine = inputLine.substring(0, inputLine.indexOf(pattern)) + inputLine.substring(inputLine.indexOf(pattern) + pattern.length(), inputLine.length());
			inputLine = inputLine.substring(0, inputLine.lastIndexOf(pattern)) + inputLine.substring(inputLine.lastIndexOf(pattern) + pattern.length(), inputLine.length());
			
			//Getting the character-to-remove position
			Integer charPos = pattern.length() / 2;
			
			//Making a substring from the beginning of the pattern to the character position 
			//and from that to the end excluding the character-to-remove
			pattern = pattern.substring(0, charPos) + pattern.substring(charPos + 1, pattern.length());
			
			//Printing "Shaked it."
			System.out.println("Shaked it.");
		}		
		
		//Printing the remainder of the string after the end of the program's main operations
		System.out.println(inputLine);
	}
}