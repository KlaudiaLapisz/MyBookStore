using MyBookStore.DTO.Authors;
using MyBookStore.Entities;
using MyBookStore.Repositories;
using MyBookStore.Services;
using NSubstitute;
using Xunit;

namespace MyBookStore.Tests.Services
{
    public class AuthorServicesTests
    {
        [Fact]
        public async Task CreateAsync_ReturnId_WhenAuthorIsCreated()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository);
            var createAuthorDto = new CreateAuthorDto
            {
                FirstName = "Jan",
                LastName = "Kowalski"
            };

            var result = await authorService.CreateAsync(createAuthorDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnFalse_WhenAuthorDoesNotExist()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository);
            var updateAuthorDto = new UpdateAuthorDto
            {
                Id = Guid.NewGuid(),
                FirstName = "Remik",
                LastName = "Mróz"
            };

            var result = await authorService.UpdateAsync(updateAuthorDto);

            Assert.False(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnTrue_WhenSuccess()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository);
            var updateAuthorDto = new UpdateAuthorDto
            {
                Id = Guid.NewGuid(),
                FirstName = "Remik",
                LastName = "Mróz"
            };

            authorRepository.GetAsync(updateAuthorDto.Id).Returns(new Author());
            var result = await authorService.UpdateAsync(updateAuthorDto);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnFalse_WhenAuthorDoesNotExist()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository);
            var deleteAuthorDto = new DeleteAuthorDto
            {
                Id = Guid.NewGuid()
            };

            var result = await authorService.DeleteAsync(deleteAuthorDto);
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnTrue_WhenSuccess()
        {
            var authorRepository = Substitute.For<IAuthorRepository>();
            var authorService = new AuthorService(authorRepository);
            var deleteAuthorDto = new DeleteAuthorDto
            {
                Id = Guid.NewGuid()
            };

            authorRepository.GetAsync(deleteAuthorDto.Id).Returns(new Author());
            var result = await authorService.DeleteAsync(deleteAuthorDto);
            Assert.True(result);
        }
    }
}

