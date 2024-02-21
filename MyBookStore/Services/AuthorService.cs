using MyBookStore.DTO.Authors;
using MyBookStore.Entities;
using MyBookStore.Repositories;

namespace MyBookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Guid?> CreateAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = createAuthorDto.FirstName,
                LastName = createAuthorDto.LastName
            };

            await _authorRepository.AddAsync(author);
            return author.Id;
        }

        public async Task<bool> UpdateAsync(UpdateAuthorDto updateAuthorDto)
        {
            var author = await _authorRepository.GetAsync(updateAuthorDto.Id);
            if (author == null)
            {
                return false;
            }
            author.FirstName = updateAuthorDto.FirstName;
            author.LastName = updateAuthorDto.LastName;

            await _authorRepository.UpdateAsync(author);
            return true;
        }

        public async Task<bool> DeleteAsync(DeleteAuthorDto deleteAuthorDto)
        {
            var author = await _authorRepository.GetAsync(deleteAuthorDto.Id);
            if (author == null)
            {
                return false;
            }

            await _authorRepository.DeleteAsync(author);
            return true;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return authors.Select(x => new AuthorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Books = x.Books.Select(z => new AuthorBookDto
                {
                    Title = z.Title
                })

            });
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = author.Books.Select(b => new AuthorBookDto
                {
                    Title = b.Title
                })
            };
        }
    }
}
