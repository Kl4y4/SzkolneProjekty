using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKolkoKrzyzykObkt {

    class Board {

        PlayerType[,] gameBoard = new PlayerType[3, 3];

        public void ClearBoard() {

            for (int i = 0; i < gameBoard.GetLength(0) * gameBoard.GetLength(1); i++) {

                gameBoard[i / 3, i % 3] = PlayerType.Empty;

            }

        }

        public PlayerType[,] GetGameBoard() {

            return gameBoard;
        
        }

        public void ChangeSymbol(int x, int y, PlayerType symbol) {

            gameBoard[x, y] = symbol;

        }
        
        public string GetSymbol(int x, int y) {

            if (gameBoard[x, y] == PlayerType.Empty) {

                return " ";

            } else { 

                return gameBoard[x, y].ToString();

            }
            
        }

    }

}
