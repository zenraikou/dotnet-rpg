using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("~/api/[controller]s")]
        public async Task<ActionResult<ServiceResponse<List<ReadCharacterDto>>>> Get()
        {
            var response = await _characterService.List();
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<List<ReadCharacterDto>>>> Create(CreateCharacterDto character)
        {
            var response = await _characterService.Create(character);

            if (response is null)
                return NotFound(response);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ReadCharacterDto>>> Read(int id)
        {
            var response = await _characterService.Read(id);

            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<ReadCharacterDto>>>> Update(UpdateCharacterDto character)
        {
            var response = await _characterService.Update(character);

            if (response is null)
                return NotFound(response);
            
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ReadCharacterDto>>>> Delete(int id)
        {
            var response = await _characterService.Delete(id);
            return Ok(response);
        }
    }
}
