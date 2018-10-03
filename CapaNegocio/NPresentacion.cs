using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Permito una comunicación con la Capa Datos para poder acceder a la Capa de Presentación
using CapaDatos;
//Para poder utilizar los tipos de datos de sqlserver:
using System.Data;


namespace CapaNegocio
{
    //Hago pública a la clase
    public class NPresentacion
    {
        //Hacer ciertos métodos que me permitan la comunicación con la Capa Datos y con la...
        //... Capa Presentación:

        //Método Insertar que llama al método Insertar de la clase DPresentación de la CapaDatos:
        public static string Insertar(string nombre, string descripcion)
        {
            //Hacemos una instancia a la clase DCategoria = new DPresentacion, voy a utilizar así
            //todos sus métodos y atributos.
            DPresentacion Obj = new DPresentacion();
            //Llamamos al método set de Nombre de la clase DPresentacion.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Nombre = nombre;
            //Lo mismo con Descripcíon:
            Obj.Descripcion = descripcion;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DPresentacion.
            //Le envío mi Obj con todos los atributos
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DPresentacion de la CapaDatos
        //Mediante el parámetro idcategoria, voy a determinar qué registro voya modificar en mi
        //base de datos.
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            //Hacemos una instancia a la clase DPresentacion = new DPresentacion, voy a utilizar así
            //todos sus métodos y atributos.
            DPresentacion Obj = new DPresentacion();
            //Al objeto idcategoria le voy a enviar idcagoria que estoy recibiendo por parámetro.
            //Primero llamo al método Idcategoria de DPresentacion de la CapaDatos.
            Obj.Idpresentacion = idpresentacion;
            //Llamamos al método set de Nombre de la clase DPresentacion.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Nombre = nombre;
            //Lo mismo con Descripcíon:
            Obj.Descripcion = descripcion;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DPresentacion.
            //Le envío mi Obj con todos los atributos
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DPresentacion de la CapaDatos.
        public static string Eliminar(int idpresentacion)
        {
            //Hacemos una instancia a la clase DPresentacion = new DPresentacion, voy a utilizar así
            //todos sus métodos y atributos.
            DPresentacion Obj = new DPresentacion();
            //Al objeto idpresentacion le voy a enviar idpresentacion que estoy recibiendo por parámetro.
            //Primero llamo al método Idpresentacion de DPresentacion de la CapaDatos.
            Obj.Idpresentacion = idpresentacion;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DPresentacion.
            //Le envío mi Obj con todos los atributos
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DPresentacion de la CapaDatos.
        //DataTable, es el valor que va a devolver
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre de la clase DPresentacion de la CapaDatos.
        public static DataTable BuscarNombre(string textobuscar)
        {
            //Instancia a mi clase DPresentacion. Obj es el objeto.
            DPresentacion Obj = new DPresentacion();
            //LLamo al método TextoBuscar para asignarle el parámetro que estoy recibiendo = textobuscar.
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
