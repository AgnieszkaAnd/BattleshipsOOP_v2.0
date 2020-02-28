using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    class Ship {
        private static Random random = new Random();
        
        public static bool IsShipHorizontal(PlayerType type, string playerInput) {
            bool horizontal = false;
			if (type == PlayerType.AI) {
                if(random.Next(2)==1) {
                    horizontal = true;
                };
            }
            else if (type == PlayerType.HUMAN) {
                if (playerInput == "h") {
                    horizontal = true;
                }
                else if (playerInput == "v") {
                    horizontal = false;
                }
                else {
                    Console.WriteLine("Wrong input. Try again");
                //DOKOŃCZYĆ ZBIERANIE INPUTU OD USERA
                }
            }

            return horizontal;
		}

    }
}
