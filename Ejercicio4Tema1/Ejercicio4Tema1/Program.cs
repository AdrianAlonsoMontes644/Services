/*Ejercicio 4
a) Crea dos hilos compitiendo que traten de incrementar (el primer hilo) o decrementar (el segundo hilo) en 1 unidad una variable que comienza en 0.

Funcionarán de forma continua hasta que a llegue a 1000 (primer hilo) o a -1000 (segundo hilo). Además se mostrará en pantalla la variable cada vez que cambie 
indicando quién la ha cambiado (thread 1 o thread 2). Ambos hilos deben parar en cuanto uno consiga su objetivo.

El Main, una vez que lanza los, hilos se queda en espera hasta que ambos hilos finalizan, luego informa de cual ha ganado.

b) Las funciones de hilos serán expresiones lambda (si quieres y los ves claro haz ya directamente este apartado).*/
class Program
{
    static readonly private object l = new object();
    static void Main(string[] args)
    {
        int i = 0;
        bool final = false;

        
            new Thread(() =>
            {
                do 
                { 
                    lock (l)
                    {
                        i--;
                        Console.SetCursorPosition(1, 1);
                        Console.Write(i);
                    }
                    if (i <= -1001)
                    {
                        final = true;
                    }
                } while (final == false);
            }).Start();


            new Thread(() =>
            {
                do 
                { 
                    lock (l)
                    {
                        i++;
                        Console.SetCursorPosition(1, 1);
                        Console.Write(i);
                    }
                    if (i >= 1001)
                    {
                        final = true;
                    }
                }while (final == false) ;
            }).Start();
            Console.ReadKey();
         
    }
}