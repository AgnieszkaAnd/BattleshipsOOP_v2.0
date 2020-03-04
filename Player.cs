using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    public enum PlayerType { HUMAN, AI };
    class Player {
        //public enum PlayerType { HUMAN, AI };
        public PlayerType Type; 
        public string Name;
        public Ocean MyOcean { get; set; }
        

        public Player(string name, PlayerType type) {
            this.Type = type;
            this.Name = name;
            this.MyOcean = new Ocean();
        }
    }
}




/*
        public string GetPlayerName (Name name) {
            Console.ReadLine("Enter player name: ")
            return name;
        }
        public string GetPlayerInput() {
            Console.WriteLine("Enter a start position of ship: ");
            Console.ReadLine().ToUpper();


            return name; 
        }

        public bool PutShipByPlayer(Square.Mark type){
            bool result = true;bool horizontal = false;
			if(random.Next(2)==1){
			horizontal = true;
			};
            
            string position = Console.ReadLine().ToUpper();
            if ( isLetter(position[0].ToString())) {
                positionX = (int) position[0]
            }
            int positionX = random.Next(10);
            int positionY = random.Next(10);
            int initx = positionX;
            int inity = positionY;
            int size = Square.GetOccupiedSquares(type);
        }
    }
    */