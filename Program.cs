using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace battle_ships {
    class Program
    {
		public enum Status {START, GAME_P_VS_P, GAME_P_VS_AI, EXIT }
        static void Main(string[] args) {
			var playersNamesInitial = new List<string> { "Player1", "Player2" };
            var playersObjects = new Player[2];
			bool theGameIsOver = false;
			string[] shipNames = Enum.GetNames(typeof(Square.Mark));
			Square.Mark[] shipTypes = (Square.Mark[])Enum.GetValues(typeof(Square.Mark));
			Status gameStatus = Status.START;
			bool isHorizontal;
			int[] position;

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
							gameStatus = Status.GAME_P_VS_P; }
						else if (choice == "2") {
							gameStatus = Status.GAME_P_VS_AI; }
						else if (choice == "3") {
							gameStatus = Status.EXIT; }
						else {
							Console.WriteLine("Choose a right option from menu.");}
						break;

					case Status.GAME_P_VS_P:
						foreach (string player in playersNamesInitial) {
                            Console.Clear();
                            Console.WriteLine($"\nPlease tell me {player} name: ");
                            int index = playersNamesInitial.IndexOf(player);
                            playersObjects[index] = new Player(Console.ReadLine(), PlayerType.HUMAN);
                            Console.WriteLine($"{player} - put your ships on the board\n" +
                            "The other player - please step out!!");
                            Thread.Sleep(3000);
                            Ship.displayShipTypes();

							//string[] shipnames = Enum.GetNames(typeof(Square.Mark));
							for( int i = 0; i < 5; i++ ) {
								Console.WriteLine($"Please place: {shipNames[i]}");
								bool shipPlaced = false;
								while (shipPlaced == false) {
									isHorizontal = Ship.IsShipHorizontal(PlayerType.HUMAN);
									position = Ocean.GetShipPosition(PlayerType.HUMAN);
									shipPlaced = playersObjects[index].MyOcean.DebugPutShip(shipTypes[i], isHorizontal, position);
								}
								System.Console.WriteLine();
								playersObjects[index].MyOcean.DebugOcean();
								System.Console.WriteLine();
							}
                        }
						

						break;

					case Status.GAME_P_VS_AI:
						Console.Clear();
						Console.WriteLine();
						break;
					
					case Status.EXIT:
						Console.Clear();
						Console.WriteLine();
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
