
using System.Runtime.CompilerServices;

namespace ArrayObjetos
{
    class Program
    {
        static void Main(string[] args) // Clase Main
        {
            var valores = new[] { 15, 28, 35, 75.5, 30.30 }; // Array implicito


            //Array de objetos
            Empleados[] arrayEmpleados = new Empleados[2]; // Creamos un array de tipo empleados y le indicamos la cantidad de posiciones del array.
            arrayEmpleados[0] = new Empleados("Mauricio", 25); // Indicamos la posicion en donde queremos almacenar el objeto de tipo empleados y le pasamos los parametros que nos solicita el constructor de empleados.
            arrayEmpleados[1] = new Empleados("Jose", 24);


            //Array de tipos o clases anonimas
            var personas = new[]
            {
            new{ Nombre="Juan", Edad=19},
            new{ Nombre="Maria", Edad=49},
            new{ Nombre="Diana", Edad=35}
            };
            for (int i = 0; i < valores.Length; i++)
            {
                Console.WriteLine(valores[i]);

            }

            foreach (var item in valores)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < arrayEmpleados.Length; i++)
            {
                Console.WriteLine(arrayEmpleados[i].getInfoEmpleados());
            }


            foreach (Empleados item in arrayEmpleados)
            {
                Console.WriteLine(item.getInfoEmpleados());
            }

            int[] numeros = new int[4]; // Creamos un array numeros de tipo entero y de 4 posiciones.
            numeros[0] = 7;
            numeros[1] = 9;
            numeros[2] = 15;
            numeros[3] = 3;

            ProcesaDatos(numeros);

            foreach (var i in numeros)
            {
                Console.WriteLine(i);
            }
        }

        static void ProcesaDatos(int[] datos) // Este metodo recorre el array que se recibe por parametro.
        {

            //foreach (var i in datos) 
            //{
            //    Console.WriteLine(i);
            //}

            for (int i = 0; i < datos.Length; i++)
            {
                datos[i] += 10; //Sumamos 10 a cada valor del array.
            }

        }

        //    int[] arrayElementos = LeerDatos();

        //    Console.WriteLine("Imprimiendo desde el main");

        //    foreach (int i in arrayElementos) 
        //    {

        //        Console.WriteLine(i); 
        //    }

        //}

        //static int [] LeerDatos()
        //{
        //    Console.WriteLine("Cuantos elementos quieres que tenga el array ?");
        //    string respuesta =  Console.ReadLine();
        //    int numElementos = int.Parse(respuesta);
        //    int[] datos = new int[numElementos]; 

        //    for (int i = 0; i < numElementos; i++)
        //    {
        //        Console.WriteLine($"Introduce el dato para la posicion {i}");
        //            respuesta = Console.ReadLine();
        //        int datosElemento = int.Parse(respuesta);
        //        datos[i] = datosElemento;
        //    }
        //        return datos;
        //}

        class Empleados // Clase empleados
        { //
            public Empleados(string nombre, int edad) // Constructor de la clase empleados
            {
                this.nombre = nombre;
                this.edad = edad;
            }

            public string getInfoEmpleados() // Metodo de acceso Getter que obtiene la informacion de las variables encapsuladas y retorna la informacion del empleado, su nombre y edad.
            {
                return "Nombre del empleado: " + nombre + " Edad: " + edad;
            }
            private string nombre; // Encapsulamos los campos para que no puedan ser modificacados fuera de la clase.
            private int edad;

        }
    }
}