using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace battle_ships {
	
    class Ocean {
    	private static Random random = new Random();
		private Square[,] Board = new Square[10,10];
		public Ocean(){
			for(int x = 0; x<10; x++){
				for(int y = 0; y<10; y++){
					Board[x,y] = new Square();
				}
			}
		}
		public void DebugOceanBack(){
			
			// Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
			Console.WriteLine("  |0|1|2|3|4|5|6|7|8|9|");

			for(int y = 0; y < 10; y++){
				if(y<9){
					// Console.Write(" "+(y+1)+"|");
					Console.Write(" "+(y)+"|");
				} else {
					// Console.Write((y+1)+"|");
					Console.Write(" "+(y)+"|");
				}
				for (int x = 0; x < 10; x++){
					Console.Write(Board[x,y].DrawBack()+"|");
				}
				Console.WriteLine("");
			}
		}

		public void DebugOceanFront(){
			
			// Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
			Console.WriteLine("  |0|1|2|3|4|5|6|7|8|9|");

			for(int y = 0; y < 10; y++){
				if(y<9){
					// Console.Write(" "+(y+1)+"|");
					Console.Write(" "+(y)+"|");
				} else {
					// Console.Write((y+1)+"|");
					Console.Write(" "+(y)+"|");
				}
				for (int x = 0; x < 10; x++){
					Console.Write(Board[x,y].DrawFront()+"|");
				}
				Console.WriteLine("");
			}
		}



		public static int[] GetShipPosition(PlayerType type) {
			int positionX = 0;
			int positionY = 0;
			if (type == PlayerType.HUMAN) {
				positionX = -1;
				positionY = -1;
				while (positionX == -1 || positionY == -1) {
					Console.WriteLine("Position:");
					string position = Console.ReadLine().ToUpper();

					if (position != null && isLetter(position[0].ToString())) {
						positionY = (int) position[0] - 65;
						if (positionY >= 10) {
							positionY = -1;
							Console.WriteLine("Column index exceeded board dimension");
						}
						if (position.Substring(1) != "" && isNumeric(position.Substring(1))) {
							positionX = Int32.Parse(position.Substring(1)) - 1;
							if (positionX >= 10) {
								positionX = -1;
								Console.WriteLine("Row index exceeded board dimension");
							}
						} else {
							Console.WriteLine("Invalid row number");
						}
					} else {
						Console.WriteLine("First input character must be a letter indcating column");
					}
				}
			}
			else if(type == PlayerType.AI) {
				positionX = random.Next(10);
				positionY = random.Next(10);
				

			}

            int[] positionInput = new int[2] { positionX, positionY };

            return positionInput;
        }
		
		
		public static bool isNumeric(string strToCheck) {
            Regex rg = new Regex(@"^[0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }

        public static bool isLetter(string strToCheck) {
            Regex rg = new Regex(@"^[a-zA-Z\s,]*$");
            return rg.IsMatch(strToCheck);
        }
		

		public bool DebugPutShip(Square.Mark type, bool isShipHorizontal, int[] position) {

			int positionX = position[0];
			int positionY = position[1];
			int initx = positionX;
			int inity = positionY;
			int size = Square.GetOccupiedSquares(type);

			var startX = positionX;
			if (startX > 0) {
				startX--;
			}
			var startY = positionY;
			if (startY > 0) {
				startY--;
			}

			var endX = positionX;
			var endY = positionY;

			if (!isShipHorizontal) {
				endY += size-1;
			}
			else {
				endX += size-1;
			}
			// if end point is not the last coordinate check one past it.
			if (endY < 9) {
				endY++;
			}

			if (endX < 9) {
				endX++;
			}

			if (!IsInsideBoard(9, startX, startY, endX, endY)) return false;

			for (int cy = startY; cy <= endY; cy++) {
				for (int cx = startX; cx <= endX; cx++) {
					if(!Board[cx, cy].IsAvailable()) return false;
				}
			}

			if(isShipHorizontal){
				for(int cx = initx; cx<size+initx; cx++){
					Board[cx, inity].SetMark(type);
				}
			} else {
				for(int cy = inity; cy<size+inity; cy++){
					Board[initx, cy].SetMark(type);
				}
			}
			return true;
		}

		

		private static bool IsInsideBoard(int boardSize, int xMin, int yMin, int xMax, int yMax) {
			if (xMin < 0 || yMin < 0 || xMax > boardSize || yMax > boardSize) {
					return false;
			}
			return true;
		}
	}
}