import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.stream.Collectors;

public class _28_BookLibrary {
    public static void main(String[] args) throws ParseException {
        Scanner scanner = new Scanner(System.in);
        int booksCount = Integer.parseInt(scanner.nextLine());
        Library library = new Library();

        for (int i = 0; i < booksCount; i++)
        {
            String[] bookInfo = scanner.nextLine().split("\\s+");

            SimpleDateFormat formatter = new SimpleDateFormat("dd.MM.yyyy");
            Date releaseDate = formatter.parse(bookInfo[3]);

            //Date releaseDate = new Date() DateTime.ParseExact(bookInfo[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            double price = Double.parseDouble(bookInfo[5]);

            library.Books.add(new Book(bookInfo[0], bookInfo[1], bookInfo[2], releaseDate, bookInfo[4], price));
        }

        // Modification method for task 6.
        // PrintAllBooksAfterDate(books);

        PrintBooksByAuthorAndPrice(library);
    }

    private static void PrintBooksByAuthorAndPrice(Library library)
    {
        Map<String, List<Book>> grouping =
               library.Books.stream().collect(Collectors.groupingBy(b -> b.Author));

        grouping.values().stream().mapToDouble(b -> b.)

        Comparator<Library> byGrade = (e1, e2) -> e2.getAvg().compareTo(e1.getAvg());
//
//        foreach (IGrouping<String, Book> bookByAuthor in grouping.OrderByDescending(b => b.Sum(bb => bb.Price)).ThenBy(b => b.Key))
//        {
//            Console.WriteLine($"{bookByAuthor.Key} -> {bookByAuthor.Sum(b => b.Price):F2}");
//        }
    }

    private static void PrintAllBooksAfterDate(List<Book> books)
    {
//        String date = Console.ReadLine();
//        DateTime afterDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
//        var allAfterDate = books.Where(b => b.ReleaseDate.CompareTo(afterDate) > 0).OrderBy(bb => bb.ReleaseDate).GroupBy(b => b.Title);
//
//        foreach (IGrouping<String, Book> grouping in allAfterDate)
//        {
//            foreach (Book book in grouping)
//            {
//                Console.WriteLine($"{book.Author} - {book.ReleaseDate.ToString("dd.MM.yyy")}");
//            }
//        }
    }
}

class Book
{
    public Book(String title, String author, String publisher, Date releaseDate, String isbn, Double price)
    {
        this.Title = title;
        this.Publisher = publisher;
        this.Author = author;
        this.ReleaseDate = releaseDate;
        this.ISBN = isbn;
        this.Price = price;
    }

    public String Title;
    public String Publisher;
    public String Author;
    public Date ReleaseDate;
    public String ISBN;
    public Double Price ;
}

class Library
{
    public Library()
    {
        this.Books = new ArrayList<Book>();
    }

    public List<Book> Books;
}