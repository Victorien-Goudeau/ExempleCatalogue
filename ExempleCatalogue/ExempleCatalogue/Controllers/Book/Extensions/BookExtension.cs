namespace ExempleCatalogue.Controllers.Book.Extensions;

using Domain.Book;
using ViewModel;

public static class BookExtension {

    public static List<BookViewModel> ToViewModel(this List<Book> books) {
        var bookViewModel = new List<BookViewModel>();

        foreach (var book in books){
            bookViewModel.Add(new BookViewModel()
            {
                Id = book.Id, Author = book.Author, Category = book.Category, Price = book.Price, BookName = book.BookName
            });
        }

        return bookViewModel;
    }
}
