using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4 {

    class Program {

        static void Main(string[] args) {

            Kategoria sprawdzian = new Kategoria(4);
            Kategoria kartkowka = new Kategoria(3);
            Kategoria pracaDomowa = new Kategoria(1);

            Ocena ocena1 = new Ocena("4", "Dziedziczenie i polimorfizm", sprawdzian);
            Ocena ocena2 = new Ocena("5", "Historia C# - referat", pracaDomowa);

            Ocena[] oceny = { ocena1, ocena2 };

            Uczen uczen1 = new Uczen("Pawel", oceny);

            uczen1.WyswietlOceny();

            Ocena ocena3 = new Ocena("3", "Klasy i konstruktory", kartkowka);


            uczen1.DodawanieOceny(ocena3);

            uczen1.WyswietlOceny();

            Console.WriteLine(uczen1.ObliczSrednia());

            Console.ReadKey();

        }

    }

    class Uczen {

        string imie;
        Ocena[] oceny;

        public float ObliczSrednia() {

            float suma = 0.0f;
            float ocena;
            int wagi = 0;
            string wartosc;
            string znak;

            for (int i = 0; i < oceny.Length; i++) {

                wartosc = oceny[i].ZwrocWartosc();

                // jeśli ocena posiada znak ( + / - )
                if (wartosc.Length > 1) {

                    // dzielenie oceny na ocenę oraz znak ( + / - )
                    znak = wartosc.Substring(1, 1);
                    ocena = float.Parse(wartosc.Remove(1));

                    if (znak == "-") {

                        ocena -= 0.25f;

                    } else if(znak == "+") {

                        ocena += 0.5f;

                    }

                } else {

                    ocena = float.Parse(wartosc);

                }

                suma += ocena * oceny[i].ZwrogWage();

                wagi += oceny[i].ZwrogWage();

            }

            float srednia = suma / wagi;

            return srednia;

        }

        public void DodawanieOceny(Ocena ocena) {

            Ocena[] ocenyTemp = new Ocena[oceny.Length + 1];

            for (int i = 0; i < ocenyTemp.Length; i++) {

                if (i == ocenyTemp.Length - 1) {

                    ocenyTemp[i] = ocena;

                } else { 

                    ocenyTemp[i] = oceny[i];

                }

            }

            oceny = ocenyTemp;

        }

        public void WyswietlOceny() {

            Console.WriteLine("Uczen {0}: ", this.imie);

            for (int i = 0; i < oceny.Length; i++) {

                Console.WriteLine("{0}({1})", oceny[i].ZwrocWartosc(), oceny[i].ZwrogWage());

            }
        
        }

        public Uczen(string imie, Ocena[] oceny) {

            this.imie = imie;
            this.oceny = oceny;

        }

    }

}
