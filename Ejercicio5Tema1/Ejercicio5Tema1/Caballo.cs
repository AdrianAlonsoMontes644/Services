/*Se recomienda realizar POO de forma que caballo sea una clase que al menos tenga 
el método correr y la propiedad (variable con set/get) posición. El array inicial será de objetos tipo caballo.
Nota: De cara a realizar pruebas de este juego, se recomienda quitar la aleatoriedad temporalmente 
para forzar a que varios caballos lleguen a un tiempo y ver que solo uno es el que “cruza” la meta. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5Tema1
{
    internal class Caballo
    {
        private int x;
        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }

        private int y;
        public int Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }

        Random random = new Random();
        public void correr()
        {
            for (int y = 0; y < 5; y=y+3)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine("/T=T`");
            }
            while (x < 50)
            {
                x = X + (int)random.Next() * 5;
                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("/T=T`");
                }catch (ArgumentOutOfRangeException)
                {

                } 
            }
        }
    }
}
