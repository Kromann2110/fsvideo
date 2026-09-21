using System.ComponentModel.DataAnnotations;
using infra;
using LinqToDB;

public class LibaryService(MyDatabaseConnection db)
{

    public List<BookDto> GetBooks(int page, int resultsPerPage)
    {
        if (page < 1)
            throw new ValidationException("Page most be 1 or higher");
        if (resultsPerPage < 1)
            throw new ValidationException("Must havve 1 or more results per page");
        
        
        return db.Books
            .LoadWith(b => b.Author)
            .ThenLoad(a  => a.BooksWrittenByAuthor)
            .Take(resultsPerPage)
            .Skip((page-1)*resultsPerPage)
            .Select(b  => new BookDto(b)
            {
                Author = new AuthorDto(b.Author)
            })
            .ToList();
    }

    public BookDto CreateBook(CreateBookRequestDto dto)
    {
        if (dto.NumberOfPages < 1)
        {
            throw new ValidationException("Number of pages must be greater than 0");
        }
        
        
        var b = new Book()
        {
            BookTitle = dto.BookTitle,
            BookId = Guid.NewGuid().ToString(),
            AuthorId = dto.AuthorId

        };
        db.Insert(b);
        return new BookDto(b);
    }
}