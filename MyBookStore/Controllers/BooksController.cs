using Microsoft.AspNetCore.Mvc;
using MyBookStore.DTO.Books;
using MyBookStore.Services;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
        {
            var result = await _bookService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> Get(Guid id)
        {
            var result = await _bookService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateBookDto createBookDto)
        {
            var id = await _bookService.CreateAsync(createBookDto);
            if (id == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateBookDto updateBookDto)
        {
            updateBookDto.Id = id;
            var result = await _bookService.UpdateAsync(updateBookDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookDto = new DeleteBookDto() { Id = id };
            var result = await _bookService.DeleteAsync(deleteBookDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
