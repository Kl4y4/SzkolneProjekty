using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKolkoKrzyzykObkt {

    public abstract class Player {

        int wins = 0;

        public void AddWin() {

            wins++;

        }

        public int GetWins() {

            return wins;

        }

        public virtual PlayerType GetSymbol() {

            return PlayerType.Empty;

        }
    
    }

    public class PlayerX : Player {

        PlayerType symbol = PlayerType.X;

        public override PlayerType GetSymbol() {

            return symbol;

        }

    }

    public class PlayerO : Player {

        PlayerType symbol = PlayerType.O;

        public override PlayerType GetSymbol() {

            return symbol;

        }

    }

}
