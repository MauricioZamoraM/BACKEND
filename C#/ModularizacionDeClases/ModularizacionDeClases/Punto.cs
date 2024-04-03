using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;  // importar metodo Math

namespace ModularizacionDeClases
{
    class Punto
    {
        public Punto(int x, int y)  //Constructor
        {
            this.x = x;
            this.y = y;

            contadorDeObjetos++;
        }

        public Punto()  //Constructor
        {
            this.x = 0;
            this.y = 0;

            contadorDeObjetos++;
        }

        public double DistanciaHasta(Punto otroPunto)
        {
            int xDif = this.x - otroPunto.x;
            int yDif = this.y - otroPunto.y;

            double distanciaPuntos = Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));

            return distanciaPuntos;
        }

        public static int ContadorDeObjetos() 
        {
            return contadorDeObjetos;
        }

        private int x , y;

        private static int contadorDeObjetos = 0;
    }
}
