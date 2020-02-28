using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace battle_ships {
    class Program
    {
        static void Main(string[] args) {

			bool theGameIsOver = false;
			Status gameStatus = Status.START;
			//public enum Status {START, GAME_P_VS_P, GAME_P_VS_AI, EXIT }
			while (!theGameIsOver) {

				switch (gameStatus) {

					case Status.START:
						Console.Title = "BATTLESHIP";
						Console.WriteLine("Welcome to Battleship!\n\n");
						Console.WriteLine("MENU:\n" + 
										"\t1) PLAYER VS PLAYER\n" +
										"\t2) PLAYER VS AI\n" +
										"\t3) EXIT GAME\n");
						string choice = Console.ReadLine();
						if (choice == "1") {
							Game.Status = Status.GAME_P_VS_P; }
						else if (choice == "2") {
							Game.Status = Status.GAME_P_VS_AI; }
						else if (choice == "3") {
							Game.Status = Status.EXIT; }
						else {
							Console.WriteLine("Choose a right option from menu.")}
						break;
					}
			}
		}
		

		/*var TestOcean = new Ocean();
		while(!TestOcean.DebugPutRandomlyShip(Square.Mark.CARRIER));
		while(!TestOcean.DebugPutRandomlyShip(Square.Mark.BATTLESHIP));
		while(!TestOcean.DebugPutRandomlyShip(Square.Mark.CRUISER));
		while(!TestOcean.DebugPutRandomlyShip(Square.Mark.SUBMARINE));
		while(!TestOcean.DebugPutRandomlyShip(Square.Mark.DESTROYER));
		
		TestOcean.DebugOcean();
		*/
        
	}
}
