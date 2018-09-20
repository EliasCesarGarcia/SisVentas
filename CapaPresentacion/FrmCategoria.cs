using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        //2 Variables. Me van a indicar si voy a registrar un artículo o lo voy a editar.
        private bool IsNuevo = false;
        private bool IsEditar = false;



        public FrmCategoria()
        {
            InitializeComponent();
            //Mostrar el mensaje de ayuda. Tenemos un control: ttMensaje
            //LLamamos a su método: SetToolTip
            //Parámetros: txtNombre que es el textbox. También el texto a mostrar.
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoría");
        }

        //Método para Mostrar Mensaje de Confirmación:
        private void MensajeOk(string mensaje)
        {
            //Mostrar primero el mensaje, parámetro: mensaje.
            //Mostrará como título: "Sistema de Ventas".
            //Mostrará un botón: MessageBoxButtons.OK.
            //Mostrará un ícono: MessageBoxIcon.Information.
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            this.txtIdcategoria.Text = string.Empty;
        }

        //Habilitar los controles de los formularios:
        private void Habilitar (bool valor)
        {
            //Este procedimiento va modificar las cajas de texto, para que estén habilitadas o
            //deshabilitadas.

            //ReadOnly: para hacerla de sólo lectura.
            //!Valor sería falso, negamos el valor que recibimos.  
            //Si recibimos true las cajas de texto van a estar habilitadas.
            //Si recibimos false, las cajas de texto van a estar deshabilitadas.
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdcategoria.ReadOnly = !valor;
        }

        //Minuto 7:25

        private void FrmCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
