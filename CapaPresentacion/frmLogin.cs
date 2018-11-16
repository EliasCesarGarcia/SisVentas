using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //En un primer momento el LblHora va a mostrar a quién?
            //Va a mostrar el día y la hora actual del Sistema: Date (día), Time(Hora), Now (actual):
            LblHora.Text = DateTime.Now.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Para que la hora se vaya mostrando cada segundo en el LblHora:
            LblHora.Text = DateTime.Now.ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //Creamos un objeto del tipo DataTable y éste reciba el DataTable resultante de la...
            //... clase NTrabajador del método Login.
            //El método Login está esperando 2 parámetros.
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.TxtUsuario.Text, this.TxtPassword.Text);
            //Evaluar si existe el Usuario ingresado en la caja de texto Usuario.
            //Datos, que es del tipo DataTable. De sus filas (Rows), las cuento (Count)
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Si existe alguna fila, podré acceder al Sistema
            else
            {
                //Creo un objeto que haga referencia al frmPrincipal
                frmPrincipal frm = new frmPrincipal();
                //Al acceder al sistema podré enviarle todos los datos:
                //Será igual a qué? a mi DataTable que se llama Datos. Obtengo la fila 0, columna 0, y lo convierto a un string.
                //Se lo paso a la variable pública Idtrabajador del frmPrincipal
                frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();

                //Le digo Show para que aparezca:
                frm.Show();
                //Para que se oculte después de acceder el frmLogin:
                this.Hide();

            }
        }
    }
}
