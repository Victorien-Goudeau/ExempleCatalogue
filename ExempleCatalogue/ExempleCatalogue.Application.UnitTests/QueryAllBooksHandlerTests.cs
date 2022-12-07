namespace ExempleCatalogue.Application.UnitTests;

using Bogus;
using Domain.Book;
using FluentAssertions;
using Interface;
using Moq;
using QueryUseCase.Book;

public class QueryAllBooksHandlerTests {

    [Fact] 
    public async Task Should_Return_All_Books_On_Demand() {
        
        var faker = new Faker();

        var repository = new Mock<IBookStoreRepository>();

        var expectedOuput = new Book { Author = faker.Person.FullName, Category = faker.Lorem.Text(), Id = faker.Lorem.Text(), Price = 42, BookName = faker.Locale };

        repository.Setup(p => p.GetAllBooks()).ReturnsAsync(new List<Book>() { expectedOuput });

        var sut = new QueryAllBooksHandler(repository.Object);

        var resultTest = await sut.Handle(new InputAllBooksUseCase());

        resultTest.First().Should().BeEquivalentTo(expectedOuput);
    }
}
