namespace ExempleCatalogue.Application.Interface;

using Domain.Book;

public interface IBookStoreRepository {
    Task<List<Book>> GetAllBooks();
    Task CreateBook(Book book);
}
