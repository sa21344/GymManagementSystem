using GymManagementAPI.DTOs;
using GymManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClassesController : ControllerBase
    {
        private readonly IFitnessClassService _service;

        public FitnessClassesController(IFitnessClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessClassReadDto>>> GetAll()
        {
            var classes = await _service.GetAllAsync();

            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessClassReadDto>> GetById(int id)
        {
            var fitnessClass = await _service.GetByIdAsync(id);

            if (fitnessClass == null)
                return NotFound();

            return Ok(fitnessClass);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<FitnessClassReadDto>> Create(
            FitnessClassCreateDto dto)
        {
            var createdClass = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdClass.Id },
                createdClass);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            FitnessClassCreateDto dto)
        {
            await _service.UpdateAsync(id, dto);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
