using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DONET_RPG.Dtos.Character;
using Microsoft.AspNetCore.Mvc;

namespace DONET_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        } 

        [HttpGet]
        [Route("GetAll")]       
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _service.GetAllCharacters());
        }

        [HttpGet]   
        [Route("{id}")]      
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await _service.GetCharacterById(id));
        }

        [HttpPost]
        [Route("CreateCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character)
        {
            return Ok(await _service.AddCharacter(character));
        } 

        [HttpPut]
        [Route("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<UpdateCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var result = await _service.UpdateCharacter(updatedCharacter);
            if (result.Data is null)
            {
                return NotFound(result);
            }
                
            return Ok(result);
        } 

    }
}