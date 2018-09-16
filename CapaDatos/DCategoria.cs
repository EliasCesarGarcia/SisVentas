using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Para trabajar con tipo de datos sql server:
using System.Data;
//Para poder enviar comandos desde nuestra aplicación a nuestra base de datos:
using System.Data.SqlClient;


//Van a estar todos los métodos para: buscar, insertar, eliminar, editar de nuestra tabla...
//...categoria.
namespace CapaDatos
{
    class DCategoria
    {
        //Atributos relacionados con nuestros campos de nuestra tabla categoría.
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;

        //Una variable más que me permitirá buscar dentro de mi tablar para poder filtrar los
        //registros.
        private string _TextoBuscar;

        //Encapsulamos todos los campos:
        //get = obtener.  set = almacenar.
        public int Idcategoria
        { get => _Idcategoria; set => _Idcategoria = value; }

        public string Nombre
        { get => _Nombre; set => _Nombre = value; }

        public string Descripcion
        { get => _Descripcion; set => _Descripcion = value; }

        public string TextoBuscar
        { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacío
        public DCategoria()
        {

        }

        //Constructor con parámetros
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            //Este Idcategoria llama al método Idcategoria, en éste caso al set.
            //Para poder almacenar el valor que está recibiendo, en éste caso idcategoria.
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Métodos para: Insertar
        //public, para que se pueda conectar con las demás capas.
        //El primer parámetro será una instancia a la clase categoría para recibirlo a manera de
        //objeto. Instancia: DCategoria.   Generamos el objeto, se llamará: categoria
        public string Insertar(DCategoria categoria)
        {
            //Función que devuelve un string
            //rpta de respuesta
            string rpta = "";
            //Hacemos una instancia a mi clase SqlConnection
            //Y el objeto que voy a crear es: SqlCon.
            SqlConnection SqlCon = new SqlConnection();
            
            //Creo un capturador de errores
            try
            {
                //Código:
                //Primero: estable la cadena de conexión. Cn (la creamos en la clase Conexion)
                SqlCon.ConnectionString = Conexion.Cn;
                //Como está cerrada, la abrimos:
                SqlCon.Open();

                //Establecer el comando que me va a permitir ejecutar sentencias en sqlserver
                SqlCommand SqlCmd = new SqlCommand();
                //Le decimos a SqlCmd que se conecte:
                SqlCmd.Connection = SqlCon;
                //Indico el nombre de objeto que voy a hacer referencia a nuestra base de datos:
                SqlCmd.CommandText = "spinsertar_categoria";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir. Son 3:
                SqlParameter ParIdcategoria = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdcategoria.ParameterName = "@idcategoria";
                //Tipo de dato:
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                //Como éste parámetro es autonumérico, es un parámetro de salida:
                ParIdcategoria.Direction = ParameterDirection.Output;
                //Agregamos éste parámetro (Idcategoria) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdcategoria);

            }

            //Si aparece un error lo almaceno en una variable: ex.
            catch (Exception ex)
            {
                //Si aparece un error, mi variable rpta va a ser igual a ese error que nos aparece.
                rpta = ex.Message;
            }

            finally
            {
                //Si la cadena de conexion está abierta, entonces la cerramos.
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        //Métodos para: Editar
        public string Editar(DCategoria categoria)
        {

        }

        //Métodos para: Eliminar
        public string Eliminar(DCategoria categoria)
        {

        }

        //Métodos para: Mostrar
        //Será Datatable, porque va a devolver todas las filas de mi tabla categoria.
        public DataTable Mostrar()
        {

        }

        //Métodos para: BuscarNombre
        public DataTable BuscarNombre(DCategoria categoria)
        {

        }
    }
}
