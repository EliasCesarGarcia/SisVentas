using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregamos
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    //Hacemos pública
    public class DProveedor
    {
        //Daclaro las variables. Una por cada campo de nuestra tabla en nuestra base de datos:
        private int _Idproveedor;
        private string _Razon_Social;
        private string _Sector_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        //Como estoy haciendo búsquedas declaro una variable opcional:
        private string _TextoBuscar;
        
        //Propiedades:
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores:

        //Constructor vacío:
        public DProveedor()
        {

        }

        //Constructor con parámtetro:
        public DProveedor(int idproveedor,
                          string razon_social,
                          string sector_comercial,
                          string tipo_documento,
                          string num_documento,
                          string direccion,
                          string telefono,
                          string email,
                          string url,
                          string textobuscar)
        {
            //Le enviamos a cada unos de sus métodos, en este caso set de cada uno, por ejemplo al método set de...
            //... "Idproveedor" le envio el "idproveedor" que estoy recibiendo como parámetro:
            this.Idproveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;
        }

        //METODOS:

        //Métodos para: Insertar
        //public, para que se pueda conectar con las demás capas.
        //El primer parámetro será una instancia a la clase DProveedor para recibirlo a manera de
        //objeto. Instancia: DCProveedor.   Generamos el objeto, se llamará: proveedor
        //Está recibiendo todo un objeto
        public string Insertar(DProveedor Proveedor)
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
                //Primero: establezco la cadena de conexión. Cn (la creamos en la clase Conexion)
                SqlCon.ConnectionString = Conexion.Cn;
                //Como está cerrada, la abrimos:
                SqlCon.Open();

                //Establecer el comando que me va a permitir ejecutar sentencias en sqlserver
                SqlCommand SqlCmd = new SqlCommand();
                //Le decimos a SqlCmd que se conecte:
                SqlCmd.Connection = SqlCon;
                //Indico el nombre de objeto que voy a hacer referencia a nuestra base de datos:
                SqlCmd.CommandText = "spinsertar_proveedor";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir.
                SqlParameter ParIdproveedor = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdproveedor.ParameterName = "@idproveedor";
                //Tipo de dato:
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                //Como éste parámetro es autonumérico, es un parámetro de salida:
                ParIdproveedor.Direction = ParameterDirection.Output;
                //Agregamos éste parámetro (Idproveedor) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdproveedor);

                //Le pondemos un nombre a nuestro parámetro: ParRazon_Social
                //Hacemos la instancia = new
                SqlParameter ParRazon_Social = new SqlParameter();
                //Hacemos la correspondencia a éste parámetro con la variable de nuestro proceso
                //almacenado en sqlsever
                ParRazon_Social.ParameterName = "@razon_social";
                //Establecer el tipo de dato:
                ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                //Establecer el tamaño del texto:
                ParRazon_Social.Size = 150; //En el DB es un varchar (150)
                //Le enviamos un valor, por eso .value. El objeto (Proveedor), enviamos todas
                //las variables de la clase DProveedor, que están declaradas arriba.
                //En éste caso llamamos al método get para obtener el nombre que tiene ese objeto.
                ParRazon_Social.Value = Proveedor.Razon_Social; //Método get
                //Agregamos.
                SqlCmd.Parameters.Add(ParRazon_Social);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.Sector_Comercial;//LLamamos al objeto "Proveedor" y su método "Sector_Comercial (Get)
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 150;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Editar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "speditar_proveedor";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir.
                SqlParameter ParIdproveedor = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdproveedor.ParameterName = "@idproveedor";
                //Tipo de dato:
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                //Valor de entrada:
                ParIdproveedor.Value = Proveedor.Idproveedor;
                //Agregamos éste parámetro (Idproveedor) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdproveedor);

                //Le pondemos un nombre a nuestro parámetro: ParRazon_Social
                //Hacemos la instancia = new
                SqlParameter ParRazon_Social = new SqlParameter();
                //Hacemos la correspondencia a éste parámetro con la variable de nuestro proceso
                //almacenado en sqlsever
                ParRazon_Social.ParameterName = "@razon_social";
                //Establecer el tipo de dato:
                ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                //Establecer el tamaño del texto:
                ParRazon_Social.Size = 150; //En el DB es un varchar (150)
                //Le enviamos un valor, por eso .value. El objeto (Proveedor), enviamos todas
                //las variables de la clase DProveedor, que están declaradas arriba.
                //En éste caso llamamos al método get para obtener el nombre que tiene ese objeto.
                ParRazon_Social.Value = Proveedor.Razon_Social; //Método get
                //Agregamos.
                SqlCmd.Parameters.Add(ParRazon_Social);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.Sector_Comercial;//LLamamos al objeto "Proveedor" y su método "Sector_Comercial (Get)
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 150;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Eliminar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "speliminar_proveedor";
                //Le indico que es un procedimiento almacenado.
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Le indicamos uno a uno los parámetros que va a recibir.
                SqlParameter ParIdproveedor = new SqlParameter();
                //Cuál va a ser su nombre en la base de datos de éste parámetro?:
                ParIdproveedor.ParameterName = "@idproveedor";
                //Tipo de dato:
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                //Valor de entrada:
                ParIdproveedor.Value = Proveedor.Idproveedor;
                //Agregamos éste parámetro (Idproveedor) a nuestro comando SqlCmd, que va a ejecutar en nuestra
                //base de datos:
                SqlCmd.Parameters.Add(ParIdproveedor);

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
            DataTable DtResultado = new DataTable("proveedor");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
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

        //Métodos para: BuscarRazon_Social
        public DataTable BuscarRazon_Social(DProveedor Proveedor)
        {
            //Hago una instancia a mi clase DataTable = DtResultado:
            DataTable DtResultado = new DataTable("proveedor");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                //LLamo a mi variable "@textobuscar" de mi procedimiento almacenado "spbuscar_proveedor_razon_social"
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                //Le envío 50 valores de texto
                ParTextoBuscar.Size = 50;
                //LLamo a mi objeto "Proveedor" y su propiedad "TextoBuscar"
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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

        //Métodos para: BuscarNum_Documento
        public DataTable BuscarNum_Documento(DProveedor Proveedor)
        {
            //Hago una instancia a mi clase DataTable = DtResultado:
            DataTable DtResultado = new DataTable("proveedor");
            //Establezco mi cadena de conexión:
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                //Le indico al comando qué cadena de conexión va a utilizar:
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                //LLamo a mi variable "@textobuscar" de mi procedimiento almacenado "spbuscar_proveedor_razon_social"
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                //Le envío 50 valores de texto
                ParTextoBuscar.Size = 50;
                //LLamo a mi objeto "Proveedor" y su propiedad "TextoBuscar"
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
