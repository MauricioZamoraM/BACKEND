namespace MetodoConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Coche coche1 = new Coche();  // Instancia de la clase Coche. Con la palabra new hacemos referencia al constructor de dicha clase y obtenemos el estado inicial del coche segun lo definido en el constructor de la clase.

            Console.WriteLine("El coche tiene: " + coche1.getRuedas() + " ruedas");
            Console.WriteLine(coche1.getInfoCoche());

            Coche coche2 = new Coche(1.5,2.5);
            Console.WriteLine(coche2.getInfoCoche());
            coche2.setExtras(true, "cuero");
            Console.WriteLine(coche2.getExtras());

        }

        partial class Coche //Partir clase en 2 partes.
        {
            // Metodo constructor, su objetivo es darle un valor inicial a los objetos de la clase. 
            public Coche()
            {
                ruedas = 4;
                largo = 2300.5;
                ancho = 0.800;
                tapizeria = "tela";
            }
        }
   /*----------------------------------------------------------------------------------------------------------*/
        partial class Coche
        {
           public Coche(double largoCoche, double anchoCoche) // Sobrecarga de constructores, podemos tener varios pero con diferente numero o tipo de parametros.
            {
                ruedas = 4;
                largo = largoCoche;
                ancho = anchoCoche;

            }
            public int getRuedas() 
            {
            return ruedas;
            }
            public string getInfoCoche()
            {
                return "El largo del coche es: " + largo + " y el ancho es " + ancho;
            }

            public void setExtras(bool climatizador, string paramTapizeria) // Metodo Setter
            {
                this.climatizador = climatizador;
                tapizeria = paramTapizeria;
            
            }

            public string getExtras()
            {
                return "Extras del coche: \n" + "Climatizador: " + climatizador + " Tapizeria: " + tapizeria;
            }


            private int ruedas;
            private double largo;
            private double ancho;
            private bool climatizador;
            private string tapizeria;

        }
    }
        

}