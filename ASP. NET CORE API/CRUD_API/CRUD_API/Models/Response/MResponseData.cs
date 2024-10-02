using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Estandar.Models.Response
{
    public class MResponseData
    {
        /// <summary>Bit para identificar si una ejecucion retorn a error.</summary>
        public bool success { get; set; }
        /// <summary>Codigo http de respuesta.</summary>
        public int code_number { get; set; }
        /// <summary>Mensaje del error.</summary>
        public string messaje_error { get; set; }
        /// <summary>Json de repuesta de la ejecucion.</summary>
        public dynamic data { get; set; }
    }
}
