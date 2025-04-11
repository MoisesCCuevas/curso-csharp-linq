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
}