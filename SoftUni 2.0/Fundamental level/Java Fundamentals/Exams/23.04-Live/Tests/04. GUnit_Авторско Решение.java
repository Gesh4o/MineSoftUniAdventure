import java.util.ArrayList;
import java.util.Collection;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class GUnit {

	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		
		//Here we initialize the structure that will hold our data.
		//Map<Class, Map<Method ArrayList<UnitTests>>>, For every class we have methods, and for every method, unit tests.
		//LinkedHashMap because StackOverflow has many sorting and collecting answers about LinkedHashMap
		LinkedHashMap<String, LinkedHashMap<String, ArrayList<String>>> classesDatabase = new LinkedHashMap<>();
		
		//We have to make some validations as stated in the problem definition.
		//"^" and "$" to mark that we match only if the string starts and ends with the specified format,
		//Constraints section specifies that the format must consist ONLY of that format.
		//[A-Z] first to ensure the beginning of the class, method, unit test with capital letter.
		//[a-zA-Z0-9] after that instead of [\\w] because [\\w] captures some symbols,
		//which are not allowed according to the problem definition.
		String pattern = "^([A-Z]{1}[a-zA-Z0-9]+) \\| ([A-Z]{1}[a-zA-Z0-9]+) \\| ([A-Z]{1}[a-zA-Z0-9]+)$";
		Pattern regex = Pattern.compile(pattern);
		
		//Here we read the first line.
		String inputLine = scanner.nextLine();
		
		//The ending condition.
		while(!inputLine.equals("It's testing time!")){
			
			//Create a matcher with the matches of the new input line.
			Matcher matcher = regex.matcher(inputLine);
			
			//Check if the line is in the correct format.
			if(matcher.find()){
				
				//Because we have groups in the regex, we can easily extract the data we need.
				//Starting from (1) because the (0) group is always the whole match.
				String className = matcher.group(1);
				String methodName = matcher.group(2);
				String unitTestName = matcher.group(3);
				
				//Check if the database contains the current class
				if(classesDatabase.containsKey(className)){
					
					//If it does, we extract the class's methods, by getting it with the class name.
					LinkedHashMap<String, ArrayList<String>> currentMethods = classesDatabase.get(className);
					
					//Check if the class's methods contain the method, in other words, the method is also not new, like the class.
					if(currentMethods.containsKey(methodName)){
						
						//If so we get the unit tests for that method.
						ArrayList<String> currentUnitTests = currentMethods.get(methodName);
						
						//If even the unit test is not new, we do nothing, as specified in the problem definition.
						//If the unit tests do not contain such a unit test, in other words, its unique, we add it.
						if(!currentUnitTests.contains(unitTestName)){
							currentUnitTests.add(unitTestName);
						}
					}
					else{
						
						//If the class's methods does not contain such a method, in other words, the method name is unique and new,
						//We create new list of unit tests, add to it the given unit test, and add to the class's methods
						//the new method with its unit test list to it.
						ArrayList<String> newUnitTests = new ArrayList<>();
						newUnitTests.add(unitTestName);
						currentMethods.put(methodName, newUnitTests);
					}
				}
				else{
					
					//If the database does not contain such a class, in other words it is unique and new,
					//We initialize new methods Map, and new unit tests List, and we add the given unit test to the List,
					//then the list and the method to the methods Map, and then the methods map, and the class name to the class database.
					LinkedHashMap<String, ArrayList<String>> newMethods = new LinkedHashMap<>();
					ArrayList<String> newUnitTests = new ArrayList<>();
					
					newUnitTests.add(unitTestName);
					newMethods.put(methodName, newUnitTests);
					classesDatabase.put(className, newMethods);
				}
			}
			
			//Maps, Lists, Arrays are all reference types, that means that we can just get them and directly new elements,
			//directly to them and they will be saved as so, even in the map, without the need to put them again or replace them
			//in the map itself.
			
			//Reading next input line
			inputLine = scanner.nextLine();
		}
		
		//And here we start the sort
		//We initialize a new map that will hold the sorted class database.
		LinkedHashMap<String, LinkedHashMap<String, ArrayList<String>>> sortedClasses = 
				classesDatabase
				//get the entry set
				.entrySet()
				//initialize stream
				.stream()
				//call the sorted method
				//lambda - in-line function
				.sorted((firstClass, secondClass) -> { 
					//getALlUnitTests is a method that you can check below the main method. 
					//class.getValue().values() returns all the unit tests for a given class, and gives them to that method
					//That method then extracts all the unit tests and returns a list of them
					//Then we just call the .size() of that list and we get the count of all unit test a class holds.
					//and we compare the second to the first in order to create a descending order.
					Integer result = Integer.valueOf(GUnit.getAllUnitTests(secondClass.getValue().values())
							.size())
							.compareTo(Integer.valueOf(GUnit.getAllUnitTests(firstClass.getValue().values())
									.size()));
					
					//If result == 0, in other words they have equal amounts of unit tests.
					if(result == 0){
						
						//class.getValue().keySet() returns a list of the names of methods for one class.
						//.size() of that returns the count of methods a class holds
						//we compare the first to the second in order to create an ascending order.
						result = Integer.valueOf(firstClass.getValue().keySet().size())
								.compareTo(Integer.valueOf(secondClass.getValue().keySet().size()));
						
						//If even then they are equal we apply the third sort, which is alphabetical
						if(result == 0){
							result = firstClass.getKey().compareTo(secondClass.getKey());
						}
					}
					
					//The in-line function requires a return value, so we return the result.
					//That value is either -1, 0 or 1 which are the return values of compareTo method.
					return result;
				})
				//Then we need to collect the map, because .stream().sorted() returns some structure, which is not good for us.
				//Second or Third Google result on "How to sort and collect a map in java"
				//We use Collectors.toMap
				//We give it functionally the methods getKey() and getValue() from the Map.Entry 
				//If something isn't okey we throw an Error. Then initialize a new map with LinkedHashMap::new
				//Calling the new keyword on LinkedHashMap.
				.collect(Collectors.toMap(
						Map.Entry::getKey,
						Map.Entry::getValue,
						(x, y) -> {throw new AssertionError();},
						LinkedHashMap::new));
		
		//After we have sorted the map we foreach it to start printing it.
		//We use entries so we can use .getKey() and .getValue() methods for easier going trough the map.
		for (Entry<String, LinkedHashMap<String, ArrayList<String>>> entryClass : sortedClasses.entrySet()) {
			System.out.println(entryClass.getKey() + ":"); //Printing the class name
			
			//getting the sorted methods for each class
			LinkedHashMap<String, ArrayList<String>> sortedMethods = entryClass
					//getting the class's methods
					.getValue()
					//same thing with the entry set and stream
					.entrySet()
					.stream()
					.sorted((firstMethod, secondMethod) -> {
						//Comparing the secondMethod's unit test count, and the first method's (descending order)
						//.getValue() returns the unit tests for every method.
						Integer result = Integer.valueOf(secondMethod.getValue().size())
								.compareTo(Integer.valueOf(firstMethod.getValue().size()));
						
						//if they are equal, do the second sorting which is alphabetical.
						if(result == 0){
							result = firstMethod.getKey().compareTo(secondMethod.getKey());
						}
						
						//return the result
						return result;
					})
					//Same collecting method.
					.collect(Collectors.toMap(
							Map.Entry::getKey,
							Map.Entry::getValue,
							(x, y) -> {throw new AssertionError();},
							LinkedHashMap::new));
			
			//Then we foreach the sortedMethods.
			for(Entry<String, ArrayList<String>> entryMethod : sortedMethods.entrySet()){
				System.out.println(String.format("##%s", entryMethod.getKey())); //Print the method name with padding - 2 "#"
				
				//And sort the unit tests.
				ArrayList<String> sortedUnitTests = entryMethod
						.getValue()
						.stream()
						.sorted((firstUnitTest, secondUnitTest) -> { 
							//Order them first by length, this time ascending ( first to second )
							Integer result = Integer.valueOf(firstUnitTest.length())
									.compareTo(Integer.valueOf(secondUnitTest.length()));
							
							//If they are equal, alphabetical order as specified in the problem definition
							if(result == 0){
								result = firstUnitTest.compareTo(secondUnitTest);
							}
							
							return result;
						})
						//This time collecting the list with Collectors.toCollection... This can be done in an easier way,
						//The sorting can be done with Collections.Sort instead of that big expression above.
						//And if you do it that way there will be no .collect because it will be unnecessary.
						.collect(Collectors.toCollection(ArrayList::new));
				
				//foreach the sorted unit tests.
				for(String unitTest : sortedUnitTests){
					System.out.println(String.format("####%s", unitTest)); //Print the unit test name with padding - 4 "#"
				}
			}
		}
	}
	
	//The method for extracting the unit tests.
	public static ArrayList<String> getAllUnitTests(Collection<ArrayList<String>> unitTests){
		
		//Receives a Collection of lists with unit tests.
		//Initialize result list
		ArrayList<String> resultSet = new ArrayList<String>();
		
		for(ArrayList<String> innerSet : unitTests){
			//go trough every unitTestsList
			for(String element : innerSet){
				//Go trough every unit test and add it to the result
				resultSet.add(element);
			}
		}
		
		//return the whole list with all the unit tests on one.
		return resultSet;
	}
}
