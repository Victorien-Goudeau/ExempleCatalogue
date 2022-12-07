namespace ExempleCatalogue.Controllers.Book;

using Application.CommandUseCase.Book;
using Application.QueryUseCase.Book;
using Domain.Book;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class BooksController : ControllerBase {

     private readonly IMediator _Mediator;
    
    private readonly ILogger<BooksController> _logger;

    public BooksController(ILogger<BooksController> logger, IMediator mediator) {
        _logger = logger;
        _Mediator = mediator;
    }

    [HttpGet(Name = "AllBooks")] public async Task<List<BookViewModel>> Get() {
        var books = await _Mediator.Send(new InputAllBooksUseCase());

        return books.ToViewModel();
    }

    [HttpPost(Name = "CreateBook")] public async Task<IActionResult> Post() {
        var book = new Book()
        {
            Author = "Erwan Martin", Category = "Robotique", Price = 42, BookName = "Comment faire exploser un robot"
        };

        await _Mediator.Send(new InputAddBookUseCase(book));

        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);

    }
}
