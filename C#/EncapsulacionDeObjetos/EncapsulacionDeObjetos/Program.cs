namespace EjemplosPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Circulo miCirculo; // Variable objeto de tipo Circulo.Objeto de circulo, tiene las propiedades de la clase circulo como pi y calculoArea.

            //miCirculo = new Circulo(); // Iniciacion de variable objeto de tipo circulo. Instancia de clase.

            //Circulo miCirculo = new Circulo();
            //Console.WriteLine(miCirculo.calculoArea(5));

            //Circulo miCirculo2 = new Circulo();
            //Console.WriteLine(miCirculo2.calculoArea(9));

            ConversorEuroDolar obj = new ConversorEuroDolar();

            obj.cambiaValorEuro(-1.45);
            Console.WriteLine(obj.convierte(50));

        }
    }
    //class Circulo
    // {
    //    const  double pi = 3.1416; // Propiedad de la clase Circulo. Tambien se conoce como campo de clase.

    //   public double calculoArea(int radio) // Metodo de clase. Que pueden hacer los objetos de tipo circulo.
    //     {
    //     return pi * radio * radio;
    //     }

    // }

    //Encapsulacion de objetos
    class ConversorEuroDolar
    {
        private double euro = 1.253; //Objeto encapsulado

        public double convierte(double cantidad)
        {
            return cantidad * euro;
        }

        public void cambiaValorEuro(double nuevoValor)
        {
            if (nuevoValor < 0)
            {
                euro = 1.253;
            }
            else
            {

                euro = nuevoValor;

            }

        }


    }
}