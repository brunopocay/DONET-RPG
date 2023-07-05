using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DONET_RPG.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }        
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}