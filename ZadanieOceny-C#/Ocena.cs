using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4 {

    class Ocena {

        string wartosc;
        string opis;
        Kategoria kategoria;

        public string ZwrocWartosc() {

            return wartosc;

        }

        public string ZwrocOpis() {

            return opis;

        }

        public int ZwrogWage() {

            return kategoria.waga;

        }

        public Ocena( string wartosc, string opis, Kategoria kategoria ) {

            this.wartosc = wartosc;
            this.opis = opis;
            this.kategoria = kategoria;

        }

    }

}
