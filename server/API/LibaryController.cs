using infra;
using Microsoft.AspNetCore.Mvc;

public class LibaryController(LibaryService service) : ControllerBase
{
    [HttpGet(template: nameof(GetBooks))]
    public List<BookDto> GetBooks(int page, int resultsPerPage)
    {
        return service.GetBooks(page, resultsPerPage);
    }

    [HttpPost(nameof(CreateBook))]
    public BookDto CreateBook(CreateBookRequestDto dto)
    {
        return service.CreateBook(dto);
    }
}