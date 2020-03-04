
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace battle_ships {
    class Program
    {
		public enum Status {START, GAME_P_VS_P, GAME_P_VS_AI, EXIT }
		static List <string> playersNamesInitial = new List<string> { "Player1", "Player2" };
		static Player[] playersObjects = new Player[2];
		static bool theGameIsOver = false;
		static string[] shipNames = Enum.GetNames(typeof(Square.Mark));
		static Square.Mark[] shipTypes = (Square.Mark[])Enum.GetValues(typeof(Square.Mark));
		static Status gameStatus = Status.START;
		static bool isHorizontal;
		static int[] position;

		static void PlaceShips(int index, PlayerType type) {
			for( int i = 0; i < 5; i++ ) {
				System.Console.WriteLine("Your current ocean:");
				playersObjects[index].MyOcean.DebugOceanBack();
				Console.WriteLine($"Please place: {shipNames[i]}");
				bool shipPlaced = false;
				while (shipPlaced == false) {
					isHorizontal = Ship.IsShipHorizontal(type);
					position = Ocean.GetShipPosition(type);
					shipPlaced = playersObjects[index].MyOcean.DebugPutShip(shipTypes[i], isHorizontal, position);
				}
				System.Console.WriteLine();
				playersObjects[index].MyOcean.DebugOceanBack();
				Thread.Sleep(5000);
				System.Console.WriteLine();
			}
		}
		
		static int PlayerSetUp(string player, List<string> playersNamesArray, Player[] playersObjectsArray, PlayerType type) {
			int playerIndex = playersNamesArray.IndexOf(player);
			Console.Clear();
			if (type == PlayerType.HUMAN) {
				Console.WriteLine($"\nPlease tell me {player} name: ");
				playersObjectsArray[playerIndex] = new Player(Console.ReadLine(), type);
				Console.WriteLine($"{player} - put your ships on the board\n" +
				"The other player - please step out!!");
				Thread.Sleep(3000);
			} else {
				playersObjectsArray[playerIndex] = new Player("Great AI player", type);
			}
			return playerIndex;
		}

        static void Main(string[] args) {

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
                            var playerIndex = PlayerSetUp(player, playersNamesInitial, playersObjects, PlayerType.HUMAN);
                            Ship.displayShipTypes();
							PlaceShips(playerIndex, PlayerType.HUMAN);
                        }
						// HERE WE MUST FINALLY CHANGE GAME STATUS - otherwise case will rerun
						break;

					case Status.GAME_P_VS_AI:
						// CREATE HUMAN PLAYER
						var index = PlayerSetUp(playersNamesInitial[0], playersNamesInitial, playersObjects, PlayerType.HUMAN);
                        Ship.displayShipTypes();
						PlaceShips(index, PlayerType.HUMAN);
						// CREATE AI PLAYER
						var index2 = PlayerSetUp(playersNamesInitial[1], playersNamesInitial, playersObjects, PlayerType.AI);
						PlaceShips(index2, PlayerType.AI);
						// HERE WE MUST FINALLY CHANGE GAME STATUS - otherwise case will rerun
						break;
					
					case Status.EXIT:
						Console.Clear();
						Console.WriteLine();
						theGameIsOver = true;
						break;
				}
			}
		}
	}
}