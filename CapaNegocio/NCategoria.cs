using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Utilizamos las clases de la Capa Datos
using CapaDatos;

using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        //Método Insertar que llama al método Insertar de la clase DCategoria de la CapaDatos:
        public static string Insertar (string nombre, string descripcion)
        {
            //Hacemos una instancia a la clase DCategoria = new DCategoria, voy a utilizar así
            //todos sus métodos y atributos.
            DCategoria Obj = new DCategoria();
            //Llamamos al método set de Nombre de la clase DCategoria.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Nombre = nombre;
            //Lo mismo con Descripcíon:
            Obj.Descripcion = descripcion;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DCategoria.
            //Le envío mi Obj con todos los atributos
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCategoria de la CapaDatos
        //Mediante el parámetro idcategoria, voy a determinar qué registro voya modificar en mi
        //base de datos.
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            //Hacemos una instancia a la clase DCategoria = new DCategoria, voy a utilizar así
            //todos sus métodos y atributos.
            DCategoria Obj = new DCategoria();
            //Al objeto idcategoria le voy a enviar idcagoria que estoy recibiendo por parámetro.
            //Primero llamo al método Idcategoria de DCategoria de la CapaDatos.
            Obj.Idcategoria = idcategoria;
            //Llamamos al método set de Nombre de la clase DCategoria.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Nombre = nombre;
            //Lo mismo con Descripcíon:
            Obj.Descripcion = descripcion;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DCategoria.
            //Le envío mi Obj con todos los atributos
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría de la CapaDatos.
        public static string Eliminar(int idcategoria)
        {
            //Hacemos una instancia a la clase DCategoria = new DCategoria, voy a utilizar así
            //todos sus métodos y atributos.
            DCategoria Obj = new DCategoria();
            //Al objeto idcategoria le voy a enviar idcagoria que estoy recibiendo por parámetro.
            //Primero llamo al método Idcategoria de DCategoria de la CapaDatos.
            Obj.Idcategoria = idcategoria;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DCategoria.
            //Le envío mi Obj con todos los atributos
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría de la CapaDatos.
        //DataTable, es el valor que va a devolver
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre de la clase DCategoría de la CapaDatos.
        public static DataTable BuscarNombre(string textobuscar)
        {
            //Instancia a mi clase DCategoria. Obj es el objeto.
            DCategoria Obj = new DCategoria();
            //LLamo al método TextoBuscar para asignarle el parámetro que estoy recibiendo = textobuscar.
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
