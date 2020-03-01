using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    class Ship {
        private static Random random = new Random();
        
        public static bool IsShipHorizontal(PlayerType type) {
            bool horizontal = false;
			if (type == PlayerType.AI) {
                if(random.Next(2)==1) {
                    horizontal = true;
                };
            }
            else if (type == PlayerType.HUMAN) {
                string playerInput = "";
                while(!(playerInput == "h" || playerInput == "v")) { 
                    Console.WriteLine("Choose a ship orientation (v/h): ");
                    playerInput = Console.ReadLine().ToLower();
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
            }

            return horizontal;
		}
            public static void displayShipTypes() {
            Console.WriteLine("\nAvailable ship types:\n" +
                "Carrier (occupies 5 squares) - Type: C\n" +
                "Battleship(4) - Type: b\n" +
                "Cruiser(3) - Type: c\n" +
                "Submarine(3) - Type: s\n" +
                "Destroyer(2) - Type: d\n");
            }
        }
    }

