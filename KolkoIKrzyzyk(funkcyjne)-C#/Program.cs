using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoIKrzyzyk {

    class Program {

        static int gracz = 1;

        static int lRund = 1;

        static int wygraneGracza1 = 0;
        static int wygraneGracza2 = 0;

        static int wolneMiejsca = 9;

        static TypGracza[,] PoleGry = new TypGracza[3, 3];
        static bool[,,] SekwencjeWygranych = new bool[8, 3, 3];

        static bool chceGrac = true;

        enum TypGracza { 
        
            Pusta,
            X,
            O,

        }

        static void ResetujPole() {

            for (int i = 0; i < PoleGry.GetLength(0) * PoleGry.GetLength(1); i++) {

                PoleGry[i / 3, i % 3] = TypGracza.Pusta;
            
            }
        
        }

        static void WypelnijSekwWygr() {

            // poziomo
            for (int i = 0; i < 3; i++) {

                SekwencjeWygranych[i, i, 0] = true;
                SekwencjeWygranych[i, i, 1] = true;
                SekwencjeWygranych[i, i, 2] = true;

            }

            // pionowo
            int temp = 0;
            for (int i = 3; i < 6; i++) {

                SekwencjeWygranych[i, 0, temp] = true;
                SekwencjeWygranych[i, 1, temp] = true;
                SekwencjeWygranych[i, 2, temp] = true;

                temp++;

            }

            // na ukos - lewo gora -> prawo dol
            SekwencjeWygranych[6, 0, 0] = true;
            SekwencjeWygranych[6, 1, 1] = true;
            SekwencjeWygranych[6, 2, 2] = true;

            // na ukos - prawo gora -> lewo dol
            SekwencjeWygranych[7, 0, 2] = true;
            SekwencjeWygranych[7, 1, 1] = true;
            SekwencjeWygranych[7, 2, 0] = true;

        }

        static void Main(string[] args) {

            WypelnijSekwWygr();

            /*

            PoleGry[1, 0] = TypGracza.X;
            PoleGry[1, 1] = TypGracza.X;
            PoleGry[1, 2] = TypGracza.X;

            SprawdzCzyWygrana();

            Console.ReadLine();

            */

            do {

                if (lRund > 1) {

                    Console.WriteLine("Czy chcesz zagrać ponownie? [0] - nie, [1] - tak");
                    string kolejnaRunda = Console.ReadLine();

                    if (kolejnaRunda.Length > 1) {

                        kolejnaRunda.Substring(0, 1);

                    }

                    while (kolejnaRunda != "0" && kolejnaRunda != "1") {

                        Console.WriteLine("Nie ma takiego wyboru.");
                        Console.WriteLine("Czy chcesz zagrać ponownie? [0] - nie, [1] - tak");

                        kolejnaRunda = Console.ReadLine();

                        if (kolejnaRunda.Length > 1) {

                            kolejnaRunda.Substring(0, 1);

                        }

                    }

                    if (kolejnaRunda == "1") { 

                        Runda();

                    } else {

                        chceGrac = false;

                    }

                } else {

                    Console.WriteLine("Witaj w grze kółko i krzyżyk!\nWciśnij ENTER, aby rozpocząć.");
                    Console.ReadLine();

                    ResetujPole();

                    Runda();

                    lRund++;

                }

                    

            } while (chceGrac);

            Console.WriteLine("Dzięki za grę!");
            Console.ReadLine();

            

        }

        static void Runda() {

            // przywrocenie wartosci poczatkowych
            gracz = 1;
            bool wygrana = false;
            TypGracza znak = TypGracza.X;

            do {

                Console.Clear();

                // sprawdzanie czy nie wystapil remis
                if (wolneMiejsca == 0) {

                    Console.WriteLine("Remis!");

                    break;

                }

                if (gracz % 2 == 0) {
                    
                    znak = TypGracza.O;
                    Console.WriteLine("Tura gracza numer 2 (O)");

                } else if (gracz % 2 == 1) {

                    znak = TypGracza.X;
                    Console.WriteLine("Tura gracza numer 1 (X)");

                }

                Rysuj();

                SprawdzPoprawnoscRuchu(znak);

                wygrana = SprawdzCzyWygrana();

                gracz++;

            } while (wygrana == false);

            Console.WriteLine("Wynik:\nGracz 1: {0}\nGracz 2: {1}", wygraneGracza1, wygraneGracza2);

            ResetujPole();

            wolneMiejsca = 9;
        
        }

        static void WykonajRuch(int wybor, TypGracza znak) {

            // odwracanie klawiatury numerycznej na pola na planszy
            int x = wybor % 3;

            if (x == 0) {

                x = (wybor / 3) - 1;
            
            } else {

                x = wybor / 3;

            }

            int y = wybor % 3;

            if (y == 0) {

                y = 4;
            
            } else {

                y = (wybor % 3) + 1;

            }

            x = Math.Abs(x - 2);
            y = Math.Abs(y - 2);

            if (PoleGry[x, y] == TypGracza.Pusta) {

                PoleGry[x, y] = znak;
                wolneMiejsca--;

            } else {

                Console.WriteLine("Wybrane pole jest już zajęte!");
                SprawdzPoprawnoscRuchu(znak);

            }

        }

        static void SprawdzPoprawnoscRuchu(TypGracza znak) {

            Console.WriteLine("\nWybierz pole za pomocą klawiatury numerycznej.");

            if (int.TryParse(Console.ReadLine(), out int wybor) && wybor > 0 && wybor < 10) {

                WykonajRuch(wybor, znak);

            } else {

                Console.WriteLine("Wybrane pole nie istnieje.");
                SprawdzPoprawnoscRuchu(znak);

            }

        }

        static bool SprawdzCzyWygrana() {

            int ileX = 0;
            int ileO = 0;

            for (int i = 0; i < 8; i++) {

                for (int y = 0; y < 3; y++) { 
                
                    for (int x = 0; x < 3; x++) { 

                        if (PoleGry[y, x] == TypGracza.X && SekwencjeWygranych[i, y, x] == true) {

                            ileX++;

                        } else if (PoleGry[y, x] == TypGracza.O && SekwencjeWygranych[i, y, x] == true) {

                            ileO++;

                        }

                    }

                }

                if (ileX == 3) {

                    Console.WriteLine("Wygrał gracz numer 1 (X)!");

                    wygraneGracza1++;
                    return true;

                } else if (ileO == 3) {

                    Console.WriteLine("Wygrał gracz numer 2 (O)!");

                    wygraneGracza2++;
                    return true;

                } 

                ileX = 0;
                ileO = 0;

            }

            return false;

        }

        static void Rysuj() { 

            for (int j = 0; j < 3; j++) { 
                 
                for (int i = 0; i < 3; i++) { 
            
                    if (PoleGry[j, i] == TypGracza.Pusta) {

                        Console.Write(" ");

                    } else {

                        Console.Write(PoleGry[j, i]);

                    }

                    if (i == 2) {

                        Console.Write("\n");

                    } else {

                        Console.Write(" | ");

                    }
            
                }

                if (j != 2) { 

                    Console.WriteLine("---------");

                }

            }

        }


    }

}
