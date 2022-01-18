using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKolkoKrzyzykObkt {

    public enum PlayerType {

        Empty,
        X,
        O,

    }

    class Program {

        static void Main(string[] args) {

            UI ui = new UI();
            Game game = new Game(ui);
            
            ui.Welcome();

            do {

                game.Round();
                game.Reset();

            } while (game.NextRound() == true);

            ui.EndScreen();

            Console.ReadKey();


        }

    }

}
