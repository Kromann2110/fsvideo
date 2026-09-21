using Facet;
using infra;

[Facet(sourceType:typeof(Book), exclude: [nameof(Book.Author), nameof(Book.BookId)]) ]
public partial class CreateBookRequestDto;