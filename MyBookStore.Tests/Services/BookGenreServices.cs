using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework;
using MyBookStore.DTO.BookGenres;
using MyBookStore.Entities;
using MyBookStore.Repositories;
using MyBookStore.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyBookStore.Tests.Services
{
    public class BookGenreServices
    {
        [Fact]
        public async Task CreateAsync_ReturnId_WhenBookGenreIsCreated()
        {
            var bookGenreRepository = Substitute.For<IBookGenreRepository>();
            var bookGereService= new BookGenreService(bookGenreRepository);
            var createBookGenreDto = new CreateBookGenreDto
            {
                GenreName = "horror"
            };

            var result = await bookGereService.CreateAsync(createBookGenreDto);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnFalse_WhenBookGenreDoesNotExist()
        {
            var bookGenreRepository=Substitute.For<IBookGenreRepository>();
            var bookGenreService = new BookGenreService(bookGenreRepository);
            var updateBookGenreDto = new UpdateBookGenreDto
            {
                Id = Guid.NewGuid(),
                GenreName = "Dramat"
            };

            var result = await bookGenreService.UpdateAsync(updateBookGenreDto);

            Assert.False(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnTrue_WhenSuccess()
        {
            var bookGenreRepository = Substitute.For<IBookGenreRepository>();
            var bookGenreService=new BookGenreService(bookGenreRepository);
            var UpdateBookGenreDto = new UpdateBookGenreDto
            {
                Id = Guid.NewGuid(),
                GenreName = "Kryminał"
            };

            bookGenreRepository.GetAsync(UpdateBookGenreDto.Id).Returns(new BookGenre());
            var result = await bookGenreService.UpdateAsync(UpdateBookGenreDto);
            Assert.True(result);
        }
    }
}
