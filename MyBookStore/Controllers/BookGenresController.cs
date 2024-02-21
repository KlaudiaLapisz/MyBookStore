using Microsoft.AspNetCore.Mvc;
using MyBookStore.DTO.BookGenres;
using MyBookStore.Services;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookGenresController : ControllerBase
    {
        private readonly IBookGenreService _bookService;

        public BookGenresController(IBookGenreService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateBookGenreDto createBookGenreDto)
        {
            var id = await _bookService.CreateAsync(createBookGenreDto);
            if (id == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateBookGenreDto updateBookGenreDto)
        {
            updateBookGenreDto.Id = id;
            var result = await _bookService.UpdateAsync(updateBookGenreDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookGenreDto = new DeleteBookGenreDto { Id = id };
            var result = await _bookService.DeleteAsync(deleteBookGenreDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookGenreDto>>> Get()
        {
            var result = await _bookService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookGenreDto>> Get(Guid id)
        {
            var result = await _bookService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
