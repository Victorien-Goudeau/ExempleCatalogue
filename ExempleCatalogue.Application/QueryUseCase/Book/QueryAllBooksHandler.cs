namespace ExempleCatalogue.Application.QueryUseCase.Book;

using Domain.Book;
using Interface;
using MediatR;

public record InputAllBooksUseCase() : IRequest<List<Book>>{}

public class QueryAllBooksHandler  : IRequestHandler<InputAllBooksUseCase, List<Book>> {
    private readonly IBookStoreRepository _bookStoreRepository;

    public QueryAllBooksHandler(IBookStoreRepository bookStoreRepository) {
        _bookStoreRepository = bookStoreRepository;
    }

    public async Task<List<Book>> Handle(InputAllBooksUseCase request, CancellationToken cancellationToken = default)
        => await _bookStoreRepository.GetAllBooks();
}
