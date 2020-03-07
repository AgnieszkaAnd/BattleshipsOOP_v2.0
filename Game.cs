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

		public static void StartScreenDisplay(int textShift) {
			System.Console.WriteLine("\t\tYou keeping us on course, Little buddy?");
			System.Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\tYes, Skipper");
			string[] shipASCII = {
				"              |    |    |",
				"             )_)  )_)  )_)",
				"            )___))___))___)",
				"           )____)____)_____)",
				"        _____|____|____|____\\__",
				"--------\\                   /---------",
				"  ^^^^^ ^^^^^^^^^^^^^^^^^^^^^",
				"    ^^^^      ^^^^     ^^^    ^^",
				"         ^^^^      ^^^"
			};
			foreach (string shipLine in shipASCII) {
				Console.SetCursorPosition(textShift, Console.CursorTop);
				System.Console.WriteLine(shipLine);
			}
		}
	}
}
