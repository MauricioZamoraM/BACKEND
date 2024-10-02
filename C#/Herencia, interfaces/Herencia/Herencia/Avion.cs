using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
     class Avion: Vehiculo
    {
        public void Aterrizar()
        {
            Console.WriteLine("Aterizando");
        }

        public void Despegar()
        {
            Console.WriteLine("Despegando");
        }

        public override void Conducir()
        {
            Console.WriteLine("Surcando los cielos");
        }
    }
}
