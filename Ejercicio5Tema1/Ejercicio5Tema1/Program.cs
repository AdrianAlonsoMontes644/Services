/*Realiza en consola el juego de carreras de caballos con al menos 5 caballos (haz un array de hilos) pero teniendo en cuenta que ahora cada caballo es un thread. 
 El usuario hace su apuesta y luego empieza la carrera de caballos de forma que cada uno se mueve una distancia aleatoria y “duerme” un tiempo aleatorio. 
 Al empezar la carrera el Main (o la función inicial) se queda en espera. Una vez que un caballo llega a la meta todos paran y el main continúa indicando el caballo ganador y si el usuario ha ganado. 
 Se permitirá la repetición del juego. No uses expresiones lambda en este ejercicio. 
*/
using Ejercicio5Tema1;

class Program
{
    static void Main(string[] args)
    {
        Caballo[] caballos = new Caballo[5];
        int elegido;
        do
        {
            Console.WriteLine("Bienvenido al hipódromo digital, haga su apuesta a uno de los 5 caballos designados");
            elegido = Convert.ToInt32(Console.ReadLine());
            if(elegido <= 0 || elegido > 5)
            {
                Console.Clear();
                Console.WriteLine("Esa no es una de las opciones");
            }
        }while(elegido <= 0 || elegido>5);

        Caballo c = new Caballo();
        c.correr();
    }

}
