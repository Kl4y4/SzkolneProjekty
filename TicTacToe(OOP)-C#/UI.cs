using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKolkoKrzyzykObkt {

    class UI {

        public void Welcome() {

            Console.Write("Welcome to TicTacToe\n" +
                "Press any key to start the game");

            Console.ReadKey();

        }

        public void DrawBoard(Board board) {

            Console.Write($"{board.GetSymbol(0, 0)} | {board.GetSymbol(0, 1)} | {board.GetSymbol(0, 2)}\n" +
                $"---------\n" +
                $"{board.GetSymbol(1, 0)} | {board.GetSymbol(1, 1)} | {board.GetSymbol(1, 2)}\n" +
                $"---------\n" +
                $"{board.GetSymbol(2, 0)} | {board.GetSymbol(2, 1)} | {board.GetSymbol(2, 2)}\n");

        }

        public void ShowScores(PlayerX player1, PlayerO player2) {

            Console.Write($"Player X: {player1.GetWins()}\n" +
                $"Player O: {player2.GetWins()}\n");

        }

        public void EndScreen() {

            Console.Write("Thank you for playing our very super epic gamer game");

        }


    }

}
