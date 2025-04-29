using System.Text.Json;
namespace curso_csharp_linq;

public class LinqQueries {

    private List<Book> libros = new List<Book>();
    public LinqQueries() {
      using StreamReader reader = new StreamReader("books.json");
      string json = reader.ReadToEnd();
      libros = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions {
        PropertyNameCaseInsensitive = true
      });
    }

    public IEnumerable<Book> AllBooks() {
      return libros;
    }

    public void PrintBooks(IEnumerable<Book> books = null) {
      Console.WriteLine("{0, -60} {1, 15} {2, 11}", "Title", "PageCount", "PublishedDate");
      foreach (var book in books ?? libros) {
        Console.WriteLine("{0, -60} {1, 15} {2, 11}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
      }
    }

    public IEnumerable<Book> BooksPublisedAfterYear(int year) {
      // expression method syntax
      // return libros.Where(b => b.PublishedDate.Year > year);
      // query syntax
      return from libro in libros
               where libro.PublishedDate.Year > year
               select libro;
    }

    public IEnumerable<Book> BooksMoreThan250PagesAndTitleContains(string title) {
      // expression method syntax
      // return libros.Where(b => b.PageCount > 250 && b.Title.Contains(title));
      // query syntax
      return from libro in libros
             where libro.PageCount > 250 && libro.Title.Contains(title)
             select libro;
    }
    public IEnumerable<Book> BooksPublishedInYear(int year) {
      // expression method syntax
      // return libros.Where(b => b.PublishedDate.Year == year);
      // query syntax
      return from libro in libros
             where libro.PublishedDate.Year == year
             select libro;
    }

    public bool AllBooksWerePublished() {
      // expression method syntax
      return libros.All(b => b.Status != string.Empty);
    }

    public bool AnyBookPublishedInYear(int year) {
      // expression method syntax
      return libros.Any(b => b.PublishedDate.Year == year);
    }

    public IEnumerable<Book> BooksWithCategory(string category) {
      // expression method syntax
      return libros.Where(b => b.Categories.Contains(category));
    }

    public IEnumerable<Book> BooksOrderedByCategoryAndTitle(string category) {
      // expression method syntax
      return libros.Where(b => b.Categories.Contains(category)).OrderBy(b => b.Title);
    }

    public IEnumerable<Book> TakeFirstThreeBooksPublishedRecentlyWithCategory( string category) {
      // expression method syntax
      return libros.Where(b => b.Categories.Contains(category)).OrderByDescending(b => b.PublishedDate).Take(3);
    }

    public IEnumerable<Book> BooksWithMoreThanPages(int pages) {
      //return libros.Where(b => b.PageCount > pages).Take(4).Skip(2);
      return libros.Where(b => b.PageCount > pages);
    }

    public IEnumerable<Book> TakeFirstThreeBooks() {
      return libros.Take(3).Select(b => new Book {
        Title = b.Title,
        PageCount = b.PageCount
      });
    }

    public int CountBooksWithPages(int min, int max) {
      return libros.Count(b => b.PageCount >= min && b.PageCount <= max);
    }

    public DateTime GetOldestPublishedDate() {
      return libros.Min(b => b.PublishedDate);
    }

    public int GetHighestPageCount() {
      return libros.Max(b => b.PageCount);
    }

    public Book GetBookWithLowestPageCount() {
      return libros.Where(b => b.PageCount > 0).MinBy(b => b.PageCount) ?? new Book();
    }

    public int SumBooksWithPageCountBetween(int min, int max) {
      return libros.Where(b => b.PageCount >= min && b.PageCount <= max).Sum(b => b.PageCount);
    }

    public string BooksTitlesConcatenatedWithPublicationDateAfter(int year) {
      return libros.Where(b => b.PublishedDate.Year > year).Aggregate("", (titulos, next) => titulos + ", " + next.Title);
    }

    public IEnumerable<IGrouping<int, Book>> GourpByBooksPulishedAfter(int year) {
      return libros.Where(b => b.PublishedDate.Year > year).GroupBy(b => b.PublishedDate.Year);
    }

    public ILookup<char, Book> DictionaryBooksByFirstLetter() {
      return libros.ToLookup(b => b.Title[0], b => b);
    }

    public IEnumerable<Book> JoinBooksBetweenTwoLists(IEnumerable<Book> books1, IEnumerable<Book> books2) {
      return books1.Join(books2, b1 => b1.Title, b2 => b2.Title, (b1, b2) => b1);
    }
}