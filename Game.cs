using System;

namespace battle_ships {
	public class Game{
		public enum Player {PLAYER_ONE, PLAYER_TWO};
		private Game.Player CurrentPlayer;

		public void StartNewGame(){
			//single/hot seats
			//player one puts 5 ships on the board
			//player two puts 5 ships on the board
		}

		// public void PlaceShips(string player) {
		// 	Console.WriteLine($"\nPlease tell me {player} name: ");
		// 	int index = playersNamesInitial.IndexOf(player);
		// 	playersObjects[index] = new Player(Console.ReadLine(), PlayerType.HUMAN);
		// 	Console.WriteLine($"{player} - put your ships on the board\n" +
		// 	"The other player - please step out!!");
		// 	Thread.Sleep(3000);
		// 	Ship.displayShipTypes();

		// 	for( int i = 0; i < 5; i++ ) {
		// 		Console.WriteLine($"Please place: {shipNames[i]}");
		// 		bool shipPlaced = false;
		// 		while (shipPlaced == false) {
		// 			isHorizontal = Ship.IsShipHorizontal(PlayerType.HUMAN);
		// 			position = Ocean.GetShipPosition(PlayerType.HUMAN);
		// 			shipPlaced = playersObjects[index].MyOcean.DebugPutShip(shipTypes[i], isHorizontal, position);
		// 		}
		// 		System.Console.WriteLine();
		// 		playersObjects[index].MyOcean.DebugOcean();
		// 		System.Console.WriteLine();
		//	}
		//}
	}
}
