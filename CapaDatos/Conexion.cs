using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {
        //Establecer la cadena de conexión. Cn = Cadena de Conexión.
        //Quién va a ser el servidor de datos: Data Source.
        //Nuestro servidor de datos: GARCIAELIAS-PC\SQLEXPRESS
        //Nombre de nuestra base de datos: Initial Catalog = dvventas
        public static string Cn = "Data Source = localhost\\sqlexpress; Initial Catalog = dvventas; Integrated Security = true";
    }
}
