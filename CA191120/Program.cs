using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191120
{
    class Program
    {
        /*
            - tölts fel egy tömböt 100db 3 számjegyű véletlen számmal.
            - írd ki a tömb elemeit, úgy, hogy egy sorban 10 elem van.
            -----
            - változtass úgy a programon, hogy kiírás közben minden 3-al osztható szám színe legyen magenta!
            - határozd meg a tömb elemeinek átlagát
            - határozd meg a tömb legnagyobb és legkisebb elemének különbségét
            - határozd meg, hogy hány db, a tömb elemeinek átlagánál nagyobb szám van a tömbben
            - írja ki egymás után, veszsővel elválasztva a tömb azon elemeit, amik oszthatóak 3-mal ÉS nagyobbak is az átlagnál

            ++ [döntse el, hoyg szerepel-e a tömbben 2 hatványa]
            - függvény + eldöntés tétele
        */
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] tomb = new int[100];
            
            //feltolt
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(100, 1000);
            }
            //kiir + szinez
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 3 == 0) Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{tomb[i]} ");
                Console.ForegroundColor = ConsoleColor.Gray;
                if ((i + 1) % 10 == 0) Console.Write("\n");
            }
            Console.Write("\n");

            //sum + atlag
            int sum = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                sum += tomb[i];
            }
            float avg = sum / (float)tomb.Length;

            Console.WriteLine($"tömb elemeinek átlaga: {avg}\n");

            //max - min
            int mini = 0;
            int maxi = 0;

            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[mini] > tomb[i]) mini = i;
                if (tomb[maxi] < tomb[i]) maxi = i;
            }

            Console.WriteLine($"legnagyobb és legkisebb elem különbsége: {tomb[maxi] - tomb[mini]}\n");

            //megszamlalas

            int db = 0;

            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] > avg) db++;
            }

            Console.WriteLine($"átlagnál nagyobb elekmek száma: {db}\n");

            //kivalogat
            Console.WriteLine("hárommal osztható, átlagnál nagyobb elemek: ");
            for (int i = 0; i < tomb.Length; i++)
            {
                if(tomb[i] > avg && tomb[i] % 3 == 0)
                {
                    Console.Write($"{tomb[i]}, ");
                }
            }

            Console.Write("\n");
            int j = 0;

            while (j < tomb.Length && !HatvanyE(tomb[j]))
            {
                j++;
            }

            if(j < tomb.Length)
            {
                Console.WriteLine($"van benne 2-nek hatványa a {j + 1}-ik helyen a {tomb[j]}");
            }
            else Console.WriteLine("nincs kettő hatványa tömbben");

            Console.ReadKey();
        }

        static bool HatvanyE(int szam)
        {
            double log = Math.Log(szam, 2);
            return log == Math.Floor(log);
        }
    }
}
