using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    public enum PlayerType { HUMAN, AI };
    class Player {
        public PlayerType Type; 
        public string Name;
        public Ocean MyOcean { get; set; }
        public ConsoleColor colorForDisplay;
        

        public Player(string name, PlayerType type) {
            this.Type = type;
            this.Name = name;
            this.MyOcean = new Ocean();
        }
    }
}