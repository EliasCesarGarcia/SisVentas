using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
//Para usar términos de Sql:
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        //Hacer ciertos métodos que me permitan la comunicación con la Capa Datos y con la...
        //... Capa Presentación:

        //Método Insertar que llama al método Insertar de la clase DArticulo de la CapaDatos:
        public static string Insertar(string codigo,
                                      string nombre,
                                      string descripcion,
                                      byte[] imagen,
                                      int idcategoria,
                                      int idpresentacion)
        {
            //Hacemos una instancia a la clase DArticulo = new DArticulo, voy a utilizar así
            //todos sus métodos y atributos.
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            //Llamamos al método set de Nombre de la clase DArticulo.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Nombre = nombre;
            //Lo mismo con Descripcíon:
            Obj.Descripcion = descripcion;

            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DArticulo.
            //Le envío mi Obj con todos los atributos
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo de la CapaDatos
        //Mediante el parámetro idarticulo, voy a determinar qué registro voya modificar en mi
        //base de datos.
        public static string Editar(int idarticulo,
                                    string codigo,
                                    string nombre,
                                    string descripcion,
                                    byte[] imagen,
                                    int idcategoria,
                                    int idpresentacion)
        {
            //Hacemos una instancia a la clase DArticulo = new DArticulo, voy a utilizar así
            //todos sus métodos y atributos.
            DArticulo Obj = new DArticulo();
            //Al objeto Idarticulo le voy a enviar idarticulo que estoy recibiendo por parámetro.
            //Primero llamo al método Idarticulo de DArticulo de la CapaDatos.
            Obj.Idarticulo = idarticulo;

            Obj.Codigo = codigo;
            
            //Llamamos al método set de Nombre de la clase DArticulo.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Nombre = nombre;
            //Lo mismo con Descripcíon:
            Obj.Descripcion = descripcion;

            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DArticulo.
            //Le envío mi Obj con todos los atributos
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo de la CapaDatos.
        public static string Eliminar(int idarticulo)
        {
            //Hacemos una instancia a la clase DArticulo = new DArticulo, voy a utilizar así
            //todos sus métodos y atributos.
            DArticulo Obj = new DArticulo();
            //Al objeto Idarticulo le voy a enviar idarticulo que estoy recibiendo por parámetro.
            //Primero llamo al método Idarticulo de DArticulo de la CapaDatos.
            Obj.Idarticulo = idarticulo;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DArticulo.
            //Le envío mi Obj con todos los atributos
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo de la CapaDatos.
        //DataTable, es el valor que va a devolver
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre de la clase DArticulo de la CapaDatos.
        //Está recibiendo un parámetro que es: textobuscar
        public static DataTable BuscarNombre(string textobuscar)
        {
            //Instancia a mi clase DArticulo. Obj es el objeto.
            DArticulo Obj = new DArticulo();
            //LLamo al método TextoBuscar para asignarle el parámetro que estoy recibiendo = textobuscar.
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
