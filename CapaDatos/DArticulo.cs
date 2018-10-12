using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
//Para comunicarse con SqlServer
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DArticulo
    {
        //Declaramos las variables por cada uno de los campos de la tabla Articulo de la DB

        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        //Un arrays tipo byte para la imagen:
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        //Me va a permitir buscar en mi tabla Articulo
        private string _TextoBuscar;

        //Encapsulamos los campos:
        //OBTENER VALOR: get: para cuando llamemos a la propiedad y queramos obtener un valor...
        //... llamará al método get y enviará el valor que tenemos por ejemplo a Idarticulo
        //ALMACENAR ALGO: set: hará lo contrario. Almacenará un valor en mi variable _Idarticulo.
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacío:
        public DArticulo()
        {

        }

        //Constructor que reciba todos los parámetros:
        public DArticulo(int idarticulo,
                         string codigo,
                         string nombre,
                         string descripcion,
                         byte[] imagen,
                         int idcategoria,
                         int idpresentacion,
                         string textobuscar)
        {
            //El constructor llama una a una las propiedades.
            //LLamo a la propiedad Idarticulo y le envía el parpametro idarticulo. Llamamos al set.
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
        }

        //Métodos:
        //Métodos para: Insertar
        //public, para que se pueda conectar con las demás capas.
        //El primer parámetro será una instancia a la clase DArticulo para recibirlo a manera de
        //objeto. Instancia: DArticulo.   Generamos el objeto, se llamará: Articulo
        public string Insertar(DArticulo Articulo)
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
                SqlCmd.CommandText = "spinsertar_articulo";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir. Son 7:
                SqlParameter ParIdarticulo = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                //Qué variable me va a afectar?: @idarticulo:
                ParIdarticulo.ParameterName = "@idarticulo";
                //Tipo de dato:
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                //Como éste parámetro es autonumérico, es un parámetro de salida:
                ParIdarticulo.Direction = ParameterDirection.Output;
                //Agregamos éste parámetro (ParIdpresentacion) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdarticulo);

                //Le pondemos un nombre a nuestro parámetro: ParCodigo
                //Hacemos la instancia = new
                SqlParameter ParCodigo = new SqlParameter();
                //Hacemos la correspondencia a éste parámetro con la variable de nuestro proceso
                //almacenado en sqlsever
                ParCodigo.ParameterName = "@codigo";
                //Establecer el tipo de dato:
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                //Establecer el tamaño del texto:
                ParCodigo.Size = 50;
                //Le enviamos un valor, por eso .value. El objeto (Articulo), enviamos todas
                //las variables de la clase DArticulo, que están declaradas arriba.
                //En éste caso llamamos al método get para obtener el nombre que tiene ese objeto.
                ParCodigo.Value = Articulo.Codigo;
                //Agregamos.
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 256;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.VarChar;
                ParIdpresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

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
        public string Editar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speditar_articulo";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir. Son 7:
                SqlParameter ParIdarticulo = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdarticulo.ParameterName = "@idarticulo";
                //Tipo de dato:
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                //Valor de entrada:
                ParIdarticulo.Value = Articulo.Idarticulo;
                //Agregamos éste parámetro (ParIdarticulo) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdarticulo);

                //Le pondemos un nombre a nuestro parámetro: ParCodigo
                //Hacemos la instancia = new
                SqlParameter ParCodigo = new SqlParameter();
                //Hacemos la correspondencia a éste parámetro con la variable de nuestro proceso
                //almacenado en sqlsever
                ParCodigo.ParameterName = "@codigo";
                //Establecer el tipo de dato:
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                //Establecer el tamaño del texto:
                ParCodigo.Size = 50;
                //Le enviamos un valor, por eso .value. El objeto (Articulo), enviamos todas
                //las variables de la clase DArticulo, que están declaradas arriba.
                //En éste caso llamamos al método get para obtener el nombre que tiene ese objeto.
                ParCodigo.Value = Articulo.Codigo;
                //Agregamos.
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 256;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.VarChar;
                ParIdpresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

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
        public string Eliminar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speliminar_articulo";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir. Son 1:
                SqlParameter ParIdarticulo = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdarticulo.ParameterName = "@idarticulo";
                //Tipo de dato:
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                //Valor de entrada:
                ParIdarticulo.Value = Articulo.Idarticulo;
                //Agregamos éste parámetro (Idarticulo) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdarticulo);

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
        //Será Datatable, porque va a devolver todas las filas de mi tabla Presentación.
        public DataTable Mostrar()
        {
            //Hago una instancia a mi clase DataTable = DtResultado:
            DataTable DtResultado = new DataTable("articulo");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            //Hago una instancia a mi clase DataTable = DtResultado:
            DataTable DtResultado = new DataTable("articulo");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
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
