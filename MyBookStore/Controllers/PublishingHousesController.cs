using Microsoft.AspNetCore.Mvc;
using MyBookStore.DTO.PublishingHouses;
using MyBookStore.Services;

namespace MyBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishingHousesController : ControllerBase
    {
        private readonly IPublishingHouseService _publishingHouseService;

        public PublishingHousesController(IPublishingHouseService publishingHouseService)
        {
            _publishingHouseService = publishingHouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishingHouseDto>>> Get()
        {
            var result = await _publishingHouseService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PublishingHouseDto>> Get(Guid id)
        {
            var result = await _publishingHouseService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreatePublishingHouseDto createPublishingHouse)
        {
            var id = await _publishingHouseService.CreateAsync(createPublishingHouse);
            if (id == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdatePublishingHouseDto updatePublishingHouseDto)
        {
            updatePublishingHouseDto.Id = id;
            var result = await _publishingHouseService.UpdateAsync(updatePublishingHouseDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePublishingHouseDto = new DeletePublishingHouseDto { Id = id };
            var result = await _publishingHouseService.DeleteAsync(deletePublishingHouseDto);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
