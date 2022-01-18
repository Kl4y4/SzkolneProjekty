using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKolkoKrzyzykObkt {

    class Game {

        int emptySpaces = 9;

        PlayerX player1 = new PlayerX();
        PlayerO player2 = new PlayerO();
        Board board = new Board();
        UI ui;
        Player curPlayer;

        public Game(UI _ui) {

            this.ui = _ui;

        }

        public void Round() {

            do {

                Console.Clear();

                CheckForTie();

                curPlayer = SetCurPlayer();

                ui.DrawBoard(board);

                CheckBoard();

            } while (CheckForWin1() == false && CheckForWin2() == false &&  CheckForTie() == false);

            ui.ShowScores(player1, player2);

        }

        public bool NextRound() {

            Console.WriteLine("\nDo you wanna play again? [0] - no, [1] - yes");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice == 0) {

                return false;

            } else if (choice == 1) {

                return true;

            } else {

                return NextRound();

            }



        }

        public void Reset() {

            emptySpaces = 9;

            board.ClearBoard();

        }
        
        public Player SetCurPlayer() {

            if (emptySpaces % 2 == 0) {

                return player2;

            } else {

                return player1;

            }

        }

        // checking if the chosen space is empty
        public void CheckBoard() {

            int choice = VerifyChoice();

            if (board.GetSymbol(CalcXCoordinate(choice), CalcYCoordinate(choice)) == " ") {

                board.ChangeSymbol(CalcXCoordinate(choice), CalcYCoordinate(choice), curPlayer.GetSymbol());

                emptySpaces--;


            } else {

                CheckBoard();

            }

        }

        public bool CheckForTie() { 

            if (emptySpaces <= 0) {

                return true;

            }

            return false;

        }

        // each win for each player (symbol)
        public bool CheckForWin1() {

            for (int i = 0; i < 3; i++) {

                if ((board.GetSymbol(i, 0) != " ") && (board.GetSymbol(i, 0) == board.GetSymbol(i, 1)) && board.GetSymbol(i, 1) == board.GetSymbol(i, 2) || (board.GetSymbol(0, i) != " ") && (board.GetSymbol(0, i) == board.GetSymbol(1, i)) && board.GetSymbol(1, i) == board.GetSymbol(2, i)) {

                    curPlayer.AddWin();
                    return true;

                }

            }

            return false;

        }

        public bool CheckForWin2() {

            if ((board.GetSymbol(1, 1) != " ") && (board.GetSymbol(0, 0) == board.GetSymbol(1, 1)) && board.GetSymbol(1, 1) == board.GetSymbol(2, 2) || (board.GetSymbol(1, 1) != " ") && (board.GetSymbol(0, 2) == board.GetSymbol(1, 1)) && board.GetSymbol(1, 1) == board.GetSymbol(2, 0)) {

                curPlayer.AddWin();
                return true;

            }


            return false;

        }

        // verifying user keyboard input
        public int VerifyChoice() {

            Console.WriteLine("\nChoose your pole using your numeric keyboard.");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 10) {

                return choice;

            } else {

                Console.WriteLine("Chosen pole doesn't exist.");
                return VerifyChoice();

            }

        }

        public int CalcXCoordinate(int choice) {

            int x = choice % 3;

            if (x == 0) {

                x = (choice / 3) - 1;

            } else {

                x = choice / 3;

            }

            x = Math.Abs(x - 2);

            return x;

        }

        public int CalcYCoordinate(int choice) {

            int y = choice % 3;

            if (y == 0) {

                y = 4;

            } else {

                y = (choice % 3) + 1;

            }

            y = Math.Abs(y - 2);

            return y;

        }


        
    }

}
