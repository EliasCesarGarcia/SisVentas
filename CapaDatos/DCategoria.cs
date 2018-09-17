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
    public class DCategoria
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
        public string Insertar(DCategoria Categoria)
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

                //Le pondemos un nombre a nuestro parámetro: ParNombre
                //Hacemos la instancia = new
                SqlParameter ParNombre = new SqlParameter();
                //Hacemos la correspondencia a éste parámetro con la variable de nuestro proceso
                //almacenado en sqlsever
                ParNombre.ParameterName = "@nombre";
                //Establecer el tipo de dato:
                ParNombre.SqlDbType = SqlDbType.VarChar;
                //Establecer el tamaño del texto:
                ParNombre.Size = 50;
                //Le enviamos un valor, por eso .value. El objeto (Categoria), enviamos todas
                //las variables de la clase DCategoria, que están declaradas arriba.
                //En éste caso llamamos al método get para obtener el nombre que tiene ese objeto.
                ParNombre.Value = Categoria.Nombre;
                //Agregamos.
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando:
                //Si ejecuta todo y devuelve un valor verdadero: "OK",
                //sino: "NO se ingresó el registro".
                rpta = SqlCmd.ExecuteNonQuery() == 1 ?
                    "OK" : "NO se ingresó el registro";
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
        public string Editar(DCategoria Categoria)
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
                SqlCmd.CommandText = "speditar_categoria";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir. Son 3:
                SqlParameter ParIdcategoria = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdcategoria.ParameterName = "@idcategoria";
                //Tipo de dato:
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                //Valor de entrada:
                ParIdcategoria.Value = Categoria.Idcategoria;
                //Agregamos éste parámetro (Idcategoria) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdcategoria);

                //Le pondemos un nombre a nuestro parámetro: ParNombre
                //Hacemos la instancia = new
                SqlParameter ParNombre = new SqlParameter();
                //Hacemos la correspondencia a éste parámetro con la variable de nuestro proceso
                //almacenado en sqlsever
                ParNombre.ParameterName = "@nombre";
                //Establecer el tipo de dato:
                ParNombre.SqlDbType = SqlDbType.VarChar;
                //Establecer el tamaño del texto:
                ParNombre.Size = 50;
                //Le enviamos un valor, por eso .value. El objeto (Categoria), enviamos todas
                //las variables de la clase DCategoria, que están declaradas arriba.
                //En éste caso llamamos al método get para obtener el nombre que tiene ese objeto.
                ParNombre.Value = Categoria.Nombre;
                //Agregamos.
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando:
                //Si ejecuta todo y devuelve un valor verdadero: "OK",
                //sino: "NO se ingresó el registro".
                rpta = SqlCmd.ExecuteNonQuery() == 1 ?
                    "OK" : "NO se actualizó el registro";
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

        //Métodos para: Eliminar
        public string Eliminar(DCategoria Categoria)
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
                SqlCmd.CommandText = "speliminar_categoria";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir. Son 3:
                SqlParameter ParIdcategoria = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdcategoria.ParameterName = "@idcategoria";
                //Tipo de dato:
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                //Valor de entrada:
                ParIdcategoria.Value = Categoria.Idcategoria;
                //Agregamos éste parámetro (Idcategoria) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdcategoria);

                //Ejecutamos nuestro comando:
                //Si ejecuta todo y devuelve un valor verdadero: "OK",
                //sino: "NO se ingresó el registro".
                rpta = SqlCmd.ExecuteNonQuery() == 1 ?
                    "OK" : "NO se actualizó el registro";
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

        //Métodos para: Mostrar
        //Será Datatable, porque va a devolver todas las filas de mi tabla categoria.
        public DataTable Mostrar()
        {
            //Hago una instancia a mi clase DataTable = DtResultado:
            DataTable DtResultado = new DataTable("categoria");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Declaro un sql DataAdapter para ejecutar el comando y llenar el DataTable:
                //Creo el objeto: SqlDat.
                //Como parámetro le mando el comando: SqlCmd.
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                //Con qué lo relleno? Con mi variable DtResultado, para llenar el DataTable:
                SqlDat.Fill(DtResultado);
            }

            catch (Exception Ex)
            {
                //Nuestra variable no va a obtener ningún valor si se tiene un error.
                DtResultado = null;
            }

            return DtResultado;
        }

        //Métodos para: BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            //Hago una instancia a mi clase DataTable = DtResultado:
            DataTable DtResultado = new DataTable("categoria");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Declaro un sql DataAdapter para ejecutar el comando y llenar el DataTable:
                //Creo el objeto: SqlDat.
                //Como parámetro le mando el comando: SqlCmd.
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                //Con qué lo relleno? Con mi variable DtResultado, para llenar el DataTable:
                SqlDat.Fill(DtResultado);
            }

            catch (Exception Ex)
            {
                //Nuestra variable no va a obtener ningún valor si se tiene un error.
                DtResultado = null;
            }

            return DtResultado;
        }
    }
}
