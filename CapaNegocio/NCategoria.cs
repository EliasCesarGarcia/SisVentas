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

        //minuto 6:22
    }
}
