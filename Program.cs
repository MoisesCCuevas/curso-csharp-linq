using curso_csharp_linq;

var linqQueries = new LinqQueries();
// var allBooks = linqQueries.AllBooks();
var libros = linqQueries.BooksPublisedAfterYear(2000);

linqQueries.PrintBooks(libros);
