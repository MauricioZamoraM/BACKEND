
namespace ModularizacionDeClases
{
    class Program
    {
        static void Main(string[] args)
        {
            //realizarTarea();

           var miVariable = new { Nombre = "Juan", Edad = 19 }; //Variable objeto = clase anonima 

            Console.WriteLine(miVariable.Nombre + "" + miVariable.Edad);
        }

        static void realizarTarea()
        { 
        Punto origen = new Punto();

        Punto destino = new Punto(1,2);

        double distancia = origen.DistanciaHasta(destino);

            Console.WriteLine($"Numero de objetos creados:  {Punto.ContadorDeObjetos()}");

        }
    }
}