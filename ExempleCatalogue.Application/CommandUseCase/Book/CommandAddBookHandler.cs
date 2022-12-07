namespace ExempleCatalogue.Application.CommandUseCase.Book;

using Domain.Book;
using Interface;
using MediatR;
public record InputAddBookUseCase(Book book) : IRequest<Unit>{}
public class CommandAddBookHandler : IRequestHandler<InputAddBookUseCase, Unit> {

    private readonly IBookStoreRepository _bookStoreRepository;

    public CommandAddBookHandler(IBookStoreRepository bookStoreRepository) {
        _bookStoreRepository = bookStoreRepository;
    }

    public async Task<Unit> Handle(InputAddBookUseCase request, CancellationToken cancellationToken = default) {
        await _bookStoreRepository.CreateBook(request.book);

        return Unit.Value;
    }

}
