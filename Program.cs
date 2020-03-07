
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
			System.Console.WriteLine("Your current ocean:");
			playersObjects[index].MyOcean.DebugOceanBack();
			for( int i = 0; i < 5; i++ ) {
				Console.WriteLine($"Please place: {shipNames[i]}");
				bool shipPlaced = false;
				while (shipPlaced == false) {
					isHorizontal = Ship.IsShipHorizontal(type);
					position = Ocean.GetShipPosition(type);
					shipPlaced = playersObjects[index].MyOcean.DebugPutShip(shipTypes[i], isHorizontal, position);
				}
				System.Console.WriteLine();
				playersObjects[index].MyOcean.DebugOceanBack();
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

		static bool ShootToShip(Player[] players) {
			int j, x, y;
			bool allShipsSunk = false;
			Square currentShot;
			for (int i = 0; i < 2; i++) {
				if (i==0) {j = 1;} else {j = 0;}

				// PRINT FRONT OF ENEMY'S OCEAN
				Console.Clear();
				System.Console.WriteLine($"{players[i].Name} - {players[i].Type} is shooting");
				players[j].MyOcean.DebugOceanFront();
				// GET POSITION FROM SHOOTING PLAYER
				Console.WriteLine("Tell me where do you want to shoot");
				position = Ocean.GetShipPosition(players[i].Type);
				x = position[1];
				y = position[0];
				// CHECK IF SHOOT IS HIT/MISS
				currentShot = players[j].MyOcean.Board[x, y];
				if (currentShot.hasBeenShot == false) {
					currentShot.hasBeenShot = true;
					if (currentShot.Back != Square.Mark.NOT_SET) {
						currentShot.Front = Square.Mark.HIT;
						System.Console.WriteLine("You got it! :D HIT");
						Thread.Sleep(3000);
						Square.Mark shipType = currentShot.Back;
						players[j].MyOcean.updateAfterHit(shipType);
						if (players[j].MyOcean.verifyAllShipsSunk()) {
							allShipsSunk = true;
							Console.Clear();
							Thread.Sleep(1000);
							System.Console.WriteLine($"{players[i].Name} - YOU WON! CONGRATS!");
							Thread.Sleep(5000);
							return allShipsSunk;
						}
						else if (players[j].MyOcean.verifyIfSunk(shipType) == true) {
							System.Console.WriteLine($"You shot {shipType}");
							Thread.Sleep(3000);
							for(int row = 0; row<10; row++){
								for(int col = 0; col<10; col++){
									if (players[j].MyOcean.Board[row, col].Back == shipType) {
										players[j].MyOcean.Board[row, col].Front = Square.Mark.SUNK;
									}
								}
							}
						}
					} else {
						currentShot.Front = Square.Mark.MISSED;
						System.Console.WriteLine("Oh no... MISS but do not worry, you will have another chance");
						Thread.Sleep(3000);
					}
				}
			}
			return allShipsSunk;
		}

		public static void CenterAlign(string text) {
		    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
		}

        static void Main(string[] args) {

			while (!theGameIsOver) {
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
				switch (gameStatus) {

					case Status.START:
						Console.Title = "BATTLESHIP";
						for (int i = Console.WindowWidth - 50; i >= 0; i--) {
							Console.Clear();
							Game.StartScreenDisplay(i);
							Thread.Sleep(20);
						}
						CenterAlign("Welcome to Battleship!"); 
						System.Console.WriteLine("\n\n");
						CenterAlign("MENU:"); 
						System.Console.WriteLine();
						CenterAlign("1) PLAYER VS PLAYER");
						CenterAlign("2) PLAYER VS AI");
						CenterAlign("3) EXIT GAME");
						// Console.WriteLine("Welcome to Battleship!\n\n");
						// Console.WriteLine("MENU:\n" + 
						// 				"\t1) PLAYER VS PLAYER\n" +
						// 				"\t2) PLAYER VS AI\n" +
						// 				"\t3) EXIT GAME\n");
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
						bool allShipsSunk = false;
						while (!allShipsSunk) {
							Console.Clear();
							allShipsSunk = ShootToShip(playersObjects);
						}
						gameStatus = Status.START;
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
						bool allShipsSunkAI = false;
						while (!allShipsSunkAI) {
							Console.Clear();
							allShipsSunkAI = ShootToShip(playersObjects);
						}
						gameStatus = Status.START;
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