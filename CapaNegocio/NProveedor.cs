using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregamos
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    //Hacemos pública la clase
    public class NProveedor
    {
        //Método Insertar que llama al método Insertar de la clase DProveedor de la CapaDatos:
        public static string Insertar(string razon_proveedor, 
                                      string sector_comercial,
                                      string tipo_documento,
                                      string num_documento,
                                      string direccion,
                                      string telefono,
                                      string email,
                                      string url)
        {
            //Hacemos una instancia a la clase DProveedor = new DProveedor, voy a utilizar así
            //todos sus métodos y atributos.
            DProveedor Obj = new DProveedor();
            //Llamamos al método set de "Razon_Social" de la clase DProveedor.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Razon_Social = razon_proveedor;
            //Lo mismo con Sector_Social:
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DProveedor.
            //Le envío mi Obj con todos los atributos
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DProveedor de la CapaDatos
        //Mediante el parámetro idproveedor, voy a determinar qué registro voya modificar en mi
        //base de datos.
        public static string Editar(  int idproveedor, 
                                      string razon_proveedor,
                                      string sector_comercial,
                                      string tipo_documento,
                                      string num_documento,
                                      string direccion,
                                      string telefono,
                                      string email,
                                      string url)
        {
            //Hacemos una instancia a la clase DProveedor = new DProveedor, voy a utilizar así
            //todos sus métodos y atributos.
            DProveedor Obj = new DProveedor();
            //Al objeto "Idproveedor" le voy a enviar "idproveedor" que estoy recibiendo por parámetro.
            //Primero llamo al método "Idproveedor" de DProveedor de la CapaDatos.
            Obj.Idproveedor = idproveedor;
            //Llamamos al método set de "Razon_Social" de la clase DProveedor.
            //Y qué le voy a enviar? el nombre que estoy recibiendo en éste método.
            Obj.Razon_Social = razon_proveedor;
            //Lo mismo con Sector_Social:
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DProveedor.
            //Le envío mi Obj con todos los atributos
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedor de la CapaDatos.
        public static string Eliminar(int idproveedor)
        {
            //Hacemos una instancia a la clase DProveedor = new DProveedor, voy a utilizar así
            //todos sus métodos y atributos.
            DProveedor Obj = new DProveedor();
            //Al objeto "Idproveedor" le voy a enviar "idproveedor" que estoy recibiendo por parámetro.
            //Primero llamo al método "Idproveedor" de DProveedor de la CapaDatos.
            Obj.Idproveedor = idproveedor;

            //Como es una función tengo que retornar algo.
            //LLamo a mi método Insertar = Obj.Insertar de mi clase DProveedor.
            //Le envío mi Obj con todos los atributos
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DProveedor de la CapaDatos.
        //DataTable, es el valor que va a devolver
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social de la clase DProveedor de la CapaDatos.
        public static DataTable BuscarRazon_Social(string textobuscar)
        {
            //Instancia a mi clase DProveedor. Obj es el objeto.
            DProveedor Obj = new DProveedor();
            //LLamo al método TextoBuscar para asignarle el parámetro que estoy recibiendo = textobuscar.
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);
        }

        //Método BuscarNum_Documento que llama al método BuscarNum_Documento de la clase DProveedor de la CapaDatos.
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            //Instancia a mi clase DProveedor. Obj es el objeto.
            DProveedor Obj = new DProveedor();
            //LLamo al método TextoBuscar para asignarle el parámetro que estoy recibiendo = textobuscar.
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
