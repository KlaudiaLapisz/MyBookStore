using Microsoft.AspNetCore.Mvc;
using MyBookStore.DTO.Borrows;
using MyBookStore.Services;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowsController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowsController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateBorrowDto createBorrowDto)
        {
            var result = await _borrowService.CreateAsync(createBorrowDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowDto>>> Get()
        {
            var result = await _borrowService.GetAllAsync();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateBorrowDto updateBorrowDto)
        {
            updateBorrowDto.BookId = id;
            var result = await _borrowService.UpdateAsync(updateBorrowDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
