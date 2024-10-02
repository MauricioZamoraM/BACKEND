using Herencia;
using System;

namespace ProyectoHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Probando el avion");
            Avion miAvion = new Avion();
            miAvion.ArrancaMotor("tracatracatraca");
            miAvion.Despegar();
            miAvion.Conducir();
            miAvion.Aterrizar();
            miAvion.PararMotor("ploff");

            
            Console.WriteLine("Probando el coche");
            Coche miCoche = new Coche();
            miCoche.ArrancaMotor("runrunrun");
            miCoche.Acelerar();
            miCoche.Conducir();
            miCoche.Frenar();
            miCoche.PararMotor("bluuff");

            Console.WriteLine("Polimorfismo en accion, utilizando el mismo metodo Conducir se va a comportar como un avion y como un coche");
            Vehiculo miVehiculo =  miCoche; // Principio de sustitucion, mi coche es un vehiculo, esto me permite guardar un objeto de tipo coche en un objeto de tipo vehiculo.
            miVehiculo.Conducir(); // metodo sobre escrito. Se comporta como coche.
            miVehiculo = miAvion;
            miVehiculo.Conducir(); // Se comporta como avion.

            Caballo Babieca = new Caballo("Babieca"); // Le pasamos por parametro el nombre del caballo.

            Humano Juan = new Humano("Juan");

            Gorilla Copito = new Gorilla("Copito");

            Mamiferos persona = new Humano("Carlos"); // Principio de sustitucion de la herencia. persona es de tipo Mamifero no de tipo persona, por ende no puede acceder a los metodos de Humano.


            //Caballo[] almacenAnimales = new Caballo[3]; // Creamos un array de tipo caballo para almacenar animales.
            //almacenAnimales[0] = Babieca; // al ser de tipo caballo si lo podemos almacenar.
            //almacenAnimales[1] = Juan; // al ser de tipo humano no lo podemos almacenar.

            // Este es el principio de sustiticion de la herencia con un ejemplo mas util
            Mamiferos[] almacenAnimales = new Mamiferos[3]; // Creamos un array de tipo mamiferos para almacenar animales.
            almacenAnimales[0] = Babieca;
            almacenAnimales[1] = Juan;
            almacenAnimales[2] = Copito;

            for (int i = 0; i < almacenAnimales.Length; i++)
            {
                almacenAnimales[i].Pensar(); // Este objeto esta comportandose de diferentes formas, dependiendo del contexto o clase.
            }

            //Juan.getNombre();
            //Babieca.getNombre();
            //Copito.getNombre();

            Console.WriteLine("Numero de patas de Babieca"+Babieca.NumeroPatas()); // Accedemos al valor del numero de patas de la interface del caballo.

        }
    }

    interface IMamiferosTerrestres // Es como una medida de seguridad para no implementar metodos en clases que no lo requieren, por ejemplo el metodo numero de patas en la clase ballena no es necesario.
    {
        //En las interfaces los metodos solo se declaran, no llevan modificador de acceso ni contenido.
        int NumeroPatas();
    }


    class Mamiferos
    {
        public Mamiferos(String nombre)
        {
            nombreSerVivo = nombre;
        }

        public void respirar()
        {
            Console.WriteLine("Soy capaz de respirar");
        }
        //  el polimorfismo se refiere a la capacidad de un objeto de una clase base para asumir diferentes formas y comportamientos según el tipo específico del objeto derivado que lo implementa.
        // El polimorfismo hace referencia a que tengamos un metodo llamado de la misma manera, con el mismo tipo y cantidad de parametros en la clase hijo, si se llaman igual pero hay diferencia en los parametros ocurre lo que se conoce como sobre carga de metodos.
        // Virtual indica que todas las clases hijas deberian heredar el metodo pensar y tambien deberian de modificarla a su conveniencia. Modificar el metodo original, el de la clase padre.
        public virtual void Pensar()
        {
            Console.WriteLine("Soy capaz de pensar");
        }

        public void cuidarCrias()
        {
            Console.WriteLine("Cuido de mis crias");
        }

        public void getNombre()
        {
            Console.WriteLine("El nombre del servivo es: " + nombreSerVivo);
        }

        private String nombreSerVivo;
    }

    class Ballena : Mamiferos
    {
        public Ballena(String nombreBallena) : base(nombreBallena) // :base llama al constructor de la clase padre y le pasa al constructor de la clase padre el nombre de la ballena
        { 
        
        }

        public void Nadar()
        {
            Console.WriteLine("Soy capaz de nadar");
        }

    }
    // IMamiferosTerrestres es una interface, obliga en la clase a utilizar los metodos que tenga.
    class Caballo : Mamiferos, IMamiferosTerrestres // Aplicamos la herencia para poder utilizar los metodos de la clase mamiferos. En caso que la clase padre tenga el constructor por defecto no tendremos ningun error, si creamos el constructor de la clase padre tendremos que utilizar :base
    {
        // El constructor recibe el nombre por parametro y se lo envia al constructor padre para que lo pueda utilizar en el metodo getNombre y ai lo imprima en consola.
        public Caballo(String nombreCaballo) : base(nombreCaballo) 
        {

        }
        public void Galopar()
        {
            Console.WriteLine("Soy capaz de galopar");
        }

        public int NumeroPatas()
        {
            return 4;
        }

        // Si queremos especificar a cual interface pertenece el metodo lo hacemos de la siguiente manera
        int IMamiferosTerrestres.NumeroPatas()
        {
            return 4;
        }
    }

    class Humano : Mamiferos
    {
        public Humano(String nombreHumano) : base(nombreHumano) // :base se debe utilizar en el constructor de la clase hijo para indicarle que vamos a utilizar la herencia de la clase padre y eliminar los errores que aparecen, hay que enviar el paremetro que espera el constructor de la clase padre.
        {

        }

        // Con el overrride indicamos que se trata de una modificaion o sobreescritura de el metodo pensar de la clase padre.
        public override void Pensar()
        {
            Console.WriteLine("Soy un humano soy capaz de pensar");
        }

    }

    class Gorilla : Mamiferos, IMamiferosTerrestres
    {
        public Gorilla(String nombreGorilla) : base(nombreGorilla) // :base se debe utilizar en el constructor de la clase hijo para indicarle que vamos a utilizar la herencia de la clase padre y eliminar los errores que aparecen, hay que enviar el paremetro que espera el constructor de la clase padre.
        {

        }
        public override void Pensar()
        {
            Console.WriteLine("Soy un gorila soy capaz de pensar");
        }

        public void Trepar()
        {
            Console.WriteLine("Soy capaz de trepar");
        }
        public int NumeroPatas()
        {
            return 2;
        }

    }
    }


//ctrl K+D