using curso_csharp_linq;

var linqQueries = new LinqQueries();
// var allBooks = linqQueries.AllBooks();
//var books = linqQueries.BooksPublisedAfterYear(2000);

// all books has status not empty
var allBooks = linqQueries.AllBooksWerePublished();
Console.WriteLine($"All books has status not empty: {allBooks}");

// any book published in 2005
var anyBook = linqQueries.AnyBookPublishedInYear(2005);
Console.WriteLine($"Any book published in 2005: {anyBook}");

//var books = linqQueries.BooksWithCategory("Python");
//Console.WriteLine($"Books with category Python: \n");

//var books = linqQueries.BooksOrderedByCategoryAndTitle("Java");
//Console.WriteLine($"Books ordered by category and title: \n");

//var books = linqQueries.TakeFirstThreeBooksPublishedRecentlyWithCategory("Java");

Console.WriteLine($"Books with pages between 200 and 500: {linqQueries.CountBooksWithPages(200, 500)} \n");

Console.WriteLine($"The oldest publication date: {linqQueries.GetOldestPublishedDate()} \n");

Console.WriteLine($"The highest page count: {linqQueries.GetHighestPageCount()} \n");

Console.WriteLine($"Book with the lowest page count: {linqQueries.GetBookWithLowestPageCount().Title} \n");

Console.WriteLine($"Titles of books with published date after 2015: {linqQueries.BooksTitlesConcatenatedWithPublicationDateAfter(2015)} \n");

var books2 = linqQueries.BooksWithMoreThanPages(500);
var books1 = linqQueries.BooksPublisedAfterYear(2005);

var joinedBooks = linqQueries.JoinBooksBetweenTwoLists(books1, books2);

linqQueries.PrintBooks(joinedBooks);
