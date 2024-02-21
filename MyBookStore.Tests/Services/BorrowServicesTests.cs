using MyBookStore.DTO.Borrows;
using MyBookStore.Entities;
using MyBookStore.Repositories;
using MyBookStore.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace MyBookStore.Tests.Services
{
    public class BorrowServicesTests
    {
        [Fact]
        public async Task CreateAsync_ReturnsFalse_WhenBookDoesNotExist()
        {
            //arrange
            var borrowRepository = Substitute.For<IBorrowRepository>();
            var bookRepository = Substitute.For<IBookRepository>();
            var borrowService = new BorrowService(borrowRepository, bookRepository);
            var createBorrowDto = new CreateBorrowDto
            {
                BookId = Guid.NewGuid(),
                BorrowBy = "Jan Kowalski",
                Notes = "test"
            };
            bookRepository.GetAsync(createBorrowDto.BookId).ReturnsNull();

            //act
            var result = await borrowService.CreateAsync(createBorrowDto);

            //assert
            Assert.False(result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsFalse_WhenBookIsBorrowed()
        {
            var borrowRepository = Substitute.For<IBorrowRepository>();
            var bookRepository = Substitute.For<IBookRepository>();
            var borrowService = new BorrowService(borrowRepository, bookRepository);
            var createBorrowDto = new CreateBorrowDto
            {
                BookId = Guid.NewGuid(),
                BorrowBy = "Jan Kowalski",
                Notes = "test"
            };
            bookRepository.GetAsync(createBorrowDto.BookId).Returns(new Book());
            var borrowList = new List<Borrow>
            {
                new Borrow()
                {
                   ReturnDate=null
                }
            };

            borrowRepository.GetAllByBook(createBorrowDto.BookId).Returns(borrowList);

            //act
            var result = await borrowService.CreateAsync(createBorrowDto);

            //assert
            Assert.False(result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsTrue_WhenSuccess()
        {

            var borrowRepository = Substitute.For<IBorrowRepository>();
            var bookRepository = Substitute.For<IBookRepository>();
            var borrowService = new BorrowService(borrowRepository, bookRepository);
            var createBorrowDto = new CreateBorrowDto
            {
                BookId = Guid.NewGuid(),
                BorrowBy = "Jan Kowalski",
                Notes = "test"
            };

            bookRepository.GetAsync(createBorrowDto.BookId).Returns(new Book());
            var borrowList = new List<Borrow>
            {
                new Borrow()
                {
                   ReturnDate=DateTime.Now
                }
            };

            borrowRepository.GetAllByBook(createBorrowDto.BookId).Returns(borrowList);

            //act
            var result = await borrowService.CreateAsync(createBorrowDto);

            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse_WhenBookDoesNotExsist()
        {
            var borrowRepository = Substitute.For<IBorrowRepository>();
            var bookRepository = Substitute.For<IBookRepository>();
            var borrowService = new BorrowService(borrowRepository, bookRepository);
            var updateBorrowDto = new UpdateBorrowDto
            {
                BookId = Guid.NewGuid(),

            };
            bookRepository.GetAsync(updateBorrowDto.BookId).ReturnsNull();

            var result = await borrowService.UpdateAsync(updateBorrowDto);

            //assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse_WhenBookIsNotBorowed()
        {
            var borrowRepository = Substitute.For<IBorrowRepository>();
            var bookRepository = Substitute.For<IBookRepository>();
            var borrowService = new BorrowService(borrowRepository, bookRepository);
            var updateBorrowDto = new UpdateBorrowDto
            {
                BookId = Guid.NewGuid(),

            };
            bookRepository.GetAsync(updateBorrowDto.BookId).Returns(new Book());
            var borrowList = new List<Borrow>
            {
                new Borrow()
                {
                   ReturnDate=DateTime.Now
                }
            };
            borrowRepository.GetAllByBook(updateBorrowDto.BookId).Returns(borrowList);

            //act
            var result = await borrowService.UpdateAsync(updateBorrowDto);

            //assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue_WhenSuccess()
        {
            //arrange
            var borrowRepository = Substitute.For<IBorrowRepository>();
            var bookRepository = Substitute.For<IBookRepository>();
            var borrowService = new BorrowService(borrowRepository, bookRepository);
            var updateBorrowDto = new UpdateBorrowDto
            {
                BookId = Guid.NewGuid(),
            };
            bookRepository.GetAsync(updateBorrowDto.BookId).Returns(new Book());
            var borrowList = new List<Borrow>
            {
                new Borrow()
                {
                   ReturnDate=null
                }
            };
            borrowRepository.GetAllByBook(updateBorrowDto.BookId).Returns(borrowList);

            //act
            var result = await borrowService.UpdateAsync(updateBorrowDto);

            //assert
            Assert.True(result);
        }
    }
}

