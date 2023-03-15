using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.CharacterDto
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Davion";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public Class Class { get; set; } = Class.Knight;
    }
}