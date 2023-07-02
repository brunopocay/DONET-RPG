using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DONET_RPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defende { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

        public static implicit operator Character(List<Character> v)
        {
            throw new NotImplementedException();
        }
    }
}