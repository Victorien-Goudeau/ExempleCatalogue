namespace ExempleCatalogue.Infrastructure.Repository;

using Application.Interface;
using Domain.Book;
using Domain.Builder;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class BookStoreRepository : IBookStoreRepository {
    
    private readonly IMongoCollection<Book> _booksCollection;

    public BookStoreRepository(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings) {
        var mongoClient = new MongoClient(
        bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
        bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Book>(
        bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Book>> GetAllBooks() {
        
        var books = await _booksCollection.Find(_ => true).ToListAsync();
        
        return books;
    }

    public async Task CreateBook(Book book) {
        await _booksCollection.InsertOneAsync(book);
    }
    
    
    
}
