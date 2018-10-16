using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Agrego
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmProveedor : Form
    {
        //Creo 2 variables que se van a usar en todo el formulario:
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();
            //Mensajes:
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese Razón Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese Número de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Proveedor");
        }

        //Método para Mostrar Mensaje de Confirmación:
        private void MensajeOk(string mensaje)
        {
            //Mostrar primero el mensaje, parámetro: mensaje.
            //Mostrará como título: "Sistema de Ventas".
            //Mostrará un botón: MessageBoxButtons.OK.
            //Mostrará un ícono: MessageBoxIcon.Information.
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método para Mostrar Mensaje de Error:
        private void MensajeError(string mensaje)
        {
            //Mostrar primero el mensaje, parámetro: mensaje.
            //Mostrará como título: "Sistema de Ventas".
            //Mostrará un botón: MessageBoxButtons.OK.
            //Mostrará un ícono: MessageBoxIcon.Error.
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para Limpiar todos los controles del formulario:
        private void Limpiar()
        {
            //Caja de texto: txtRazon_Social.
            //Para dejar en blanco: string.Empty.
            this.txtRazon_Social.Text = string.Empty;
            //Caja de texto: txtNum_Documento.
            this.txtNum_Documento.Text = string.Empty;
            //Caja de texto: txtDireccion.
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;
        }

        //Habilitar los controles de los formularios:
        private void Habilitar(bool valor)
        {
            //Este procedimiento va modificar las cajas de texto, para que estén habilitadas o
            //deshabilitadas.

            //ReadOnly: para hacerla de sólo lectura.
            //!Valor sería falso, negamos el valor que recibimos.  
            //Si recibimos true las cajas de texto van a estar habilitadas.
            //Si recibimos false, las cajas de texto van a estar deshabilitadas.
            this.txtRazon_Social.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor; //"!valor", negamos lo que recibimos. 
            this.cbSector_comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdproveedor.ReadOnly = !valor;
        }

        //Habilitar los botones:
        private void Botones()
        {
            //Éste procedimiento va a habilitar o deshabilitar ciertos botonos.
            //Si IsNuevo está activado, es decir si se va a registrar un proveedor...
            //O está activado IsEditar:
            if (this.IsNuevo || this.IsEditar)
            {
                //LLamamos a nuesto método Habilitar para las cajas de texto:
                this.Habilitar(true);
                //Deshabilite el botón:
                this.btnNuevo.Enabled = false;
                //Habilitamos el botón guardar:
                this.btnGuardar.Enabled = true;
                //Dehabilitamos el botón editar:
                this.btnEditar.Enabled = false;
                //Habilitamos el botón cancelar:
                this.btnCancelar.Enabled = true;
            }
            else
            {
                //Si no está insertando o editando un registro, deshabilitamos las cajas de texto: false.
                this.Habilitar(false);
                //Habilitamos el botón Nuevo, para que pueda registrar el artículo:
                this.btnNuevo.Enabled = true;
                //Deshabilitamos el botón guardar, ya que no ingresamos nada, no puede guardar.
                this.btnGuardar.Enabled = false;
                //Habilitamos el botón editar:
                this.btnEditar.Enabled = true;
                //Habilitamos el botón cancelar:
                this.btnCancelar.Enabled = false;
            }
        }

        //Método para ocultar columnas:
        private void OcultarColumnas()
        {
            //False: para que no esté visible:
            //Oculto la columna: Eliminar [0]
            //Oculto la columna: idcategoria [1]
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar todos los registros de la tabla proveedores:
        private void Mostrar()
        {
            //LLamo a mi clase NProveedor, donde está mi procedimiento: Mostrar, para que me envíe...
            //... ciertos valores.
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Métod BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            //LLamo a mi clase NProveedor, donde está mi procedimiento: BuscarRazonSocial, para que me envíe...
            //... ciertos valores.
            //BuscarRazon_Social, está esperando un parámetro: la caja de texto: txtBuscar
            //Y obtengo el texto con su propiedad: .Text
            this.dataListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Métod BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            //LLamo a mi clase NProveedor, donde está mi procedimiento: BuscarNum_Documento, para que me envíe...
            //... ciertos valores.
            //BuscarNum_Documento, está esperando un parámetro: la caja de texto: txtBuscar
            //Y obtengo el texto con su propiedad: .Text
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
