using System;
using System.Collections.Generic;
using System.Text;

namespace MapsAndModels.ViewModels
{
    public class CharacterModel
    {
        public string Token { get; set; }

        public int Id { get; set; }

        public string UserName { get; set; }
        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }
        public decimal PositionZ { get; set; }
        public int FacingDirection { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }
    }
}
