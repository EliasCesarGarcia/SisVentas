using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Me comunico con la Capa Negocio
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmPresentacion : Form
    {
        //2 Variables. Me van a indicar si voy a registrar un artículo o lo voy a editar.
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmPresentacion()
        {
            //Este método inicializa todos los controles:
            InitializeComponent();
            //Mostrar el mensaje de ayuda. Tenemos un control: ttMensaje
            //LLamamos a su método: SetToolTip
            //Parámetros: txtNombre que es el textbox. También el texto a mostrar.
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Presentación");
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
            //Caja de texto: txtNombre.
            //Para dejar en blanco: string.Empty.
            this.txtNombre.Text = string.Empty;
            //Caja de texto: txtDescripcion.
            this.txtDescripcion.Text = string.Empty;
            //Caja de texto: txtIdcategoria.
            this.txtIdpresentacion.Text = string.Empty;
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
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdpresentacion.ReadOnly = !valor;
        }

        //Habilitar los botones:
        private void Botones()
        {
            //Éste procedimiento va a habilitar o deshabilitar ciertos botonos.
            //Si IsNuevo está activado, es decir si se va a registrar un artículo...
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

        //Método Mostrar todos los registros de la tabla presentacion:
        private void Mostrar()
        {
            //LLamo a mi clase NPresentacion, donde está mi procedimiento: Mostrar, para que me envíe...
            //... ciertos valores.
            this.dataListado.DataSource = NPresentacion.Mostrar();
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre.
        private void BuscarNombre()
        {
            //LLamo a mi clase NPresentacion, donde está mi procedimiento: BuscarNombre, para que me envíe...
            //... ciertos valores.
            //BuscarNombre, está esperando un parámetro: la caja de texto: txtBuscar
            //Y obtengo el texto con su propiedad: .Text
            this.dataListado.DataSource = NPresentacion.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            //Primero, ubicar nuestro formulario:
            //En la esquina superior:
            this.Top = 0;
            //Alineado en la izquierda:
            this.Left = 0;

            this.Mostrar();
            //Le digo que las cajas de texto no estén habilitadas o sean de sólo lectura:
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Cada vez que el usuario escriba algo, envíe la petición a la capa Negocio, la Capa Negocio...
            //... a la Capa Datos y se filtre en nuestra Base de Datos.
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Cuando se haga clic en este botón (IsNuevo), se va registrar un artículo.
            //La variable IsNuevo, se va a convertir en verdadera:
            this.IsNuevo = true;
            //No voy a editar, sino a registrar un artículo, por eso será falsa:
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //Habilitar las cajas de texto con true:
            this.Habilitar(true);
            //Enviar el enfoque a ésta caja de texto:
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaro una variable para evaluar si se insertó o modificó:
                string rpta = "";
                //Voy a validar los datos. En éste caso, el campo Nombre no puede estar vacío:
                //string.Empty = quiere decir que está vacía:
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    //Que el icono de error aparezca al costado de la caja de texto: txtNombre.
                    erroricono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    //El usuario quiere realizar un registro:
                    if (this.IsNuevo)
                    {
                        //Se envían 2 parámatros: txtNombre, para enviar el nombre. Y descripción.
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NPresentacion.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                                                   this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        //Se envían 3 parámatros.
                        //Como es un string: this.txtIdpresentacion.Text, lo paso a un int: Convert.ToInt32
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NPresentacion.Editar(Convert.ToInt32(this.txtIdpresentacion.Text),
                                                 this.txtNombre.Text.Trim().ToUpper(),
                                                 this.txtDescripcion.Text.Trim());
                    }

                    //Esto es para la respuesta (rpta) de DCategoria, en el método insertar:
                    //Equals: para comparar una cadena.
                    if (rpta.Equals("OK")) //OK, es si se insertó o modificó.
                    {
                        //Recibo un OK del insertr, porque IsNuevo está en true en el if:
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("se insertó de forma correcta el registro");
                        }
                        //Si no es Insertar(IsNuevo) es un editar:
                        else
                        {
                            this.MensajeOk("se actualizó de forma correcta el registro");
                        }
                    }
                    //Si No recibo un OK:
                    else
                    {
                        //rpta, es el que recibe los mensajes.
                        this.MensajeError(rpta);
                    }

                    //Lo dejó en false, porque ya ingresé el registro:
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    //Para Mostrar actualizado nuestro datalistado:
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
