using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await _service.GetAllCharacters());
        }

        [HttpGet]   
        [Route("{id}")]      
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {
            return Ok(await _service.GetCharacterById(id));
        }

        [HttpPost]
        [Route("CreateCharacter")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character character)
        {
            return Ok(await _service.AddCharacter(character));
        } 

    }
}