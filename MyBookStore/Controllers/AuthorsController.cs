using Microsoft.AspNetCore.Mvc;
using MyBookStore.DTO.Authors;
using MyBookStore.Services;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var result = await _authorService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorDto>> Get(Guid id)
        {
            var result = await _authorService.GetAsync(id);
            if (result ==  null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAuthorDto createAuthorDto)
        {
            var id = await _authorService.CreateAsync(createAuthorDto);
            if (id == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateAuthorDto updateAuthorDto)
        {
            updateAuthorDto.Id = id;
            var result = await _authorService.UpdateAsync(updateAuthorDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAuthorDto = new DeleteAuthorDto { Id = id };
            var result = await _authorService.DeleteAsync(deleteAuthorDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
