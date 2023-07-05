using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DONET_RPG.Dtos.Character;

namespace DONET_RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponse<UpdateCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
    }
}