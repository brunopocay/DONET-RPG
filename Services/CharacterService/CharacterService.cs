global using AutoMapper;
using DONET_RPG.Dtos.Character;
using DONET_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DONET_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();           
            var character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();   
            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            
            try
            {       
                var character = _context.Characters.First(c => c.Id == id);                            
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception er)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = er.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();  
            var dbCharacter = await _context.Characters.ToListAsync();          
            serviceResponse.Data = dbCharacter.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                if(dbCharacter is null)
                    throw new Exception("Could not find character with id: " + id );
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }
            catch (Exception er)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = er.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UpdateCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<UpdateCharacterDto>();
            
            try
            {
                var character = _context.Characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if(character is null)
                    throw new Exception($"Character with Id {updatedCharacter.Id} not found.");

                character.Name = updatedCharacter.Name;            
                character.Class = updatedCharacter.Class;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UpdateCharacterDto>(character);
            }
            catch (Exception er)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = er.Message;
            }
            return serviceResponse;
        }
    }
}
