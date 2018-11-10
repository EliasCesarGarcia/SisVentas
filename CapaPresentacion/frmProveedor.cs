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
            this.cbSector_Comercial.Enabled = valor;
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
            this.dataListado.DataSource = NProveedor.BuscarRazon_social(this.txtBuscar.Text);
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



        private void frmProveedor_Load(object sender, EventArgs e)
        {
            //Aparezca en la parte superior:
            this.Top = 0;
            //Aparezca en la parte izquierda:
            this.Left = 0;
            //Cuando se active el formulario, llame los siguientes métodos:
            this.Mostrar();
            //Que le envíe el parámetro "false" para que en un primer momento no estén habilitados...
            //... ninguno de los controles:
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Valido el combobox "cbBuscar", para evaluar la búsqueda por Razón Social o Documento...
            //... ambos búsquedas tienen sus procesos almacenados.
            //Lo que tento en mi propiedad ".Text"...
            //... y lo comparo con el método Equals:
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                //Voy a llamar a mi método "BuscarRazon_Social"
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                //Voy a llamar a mi método "BuscarNum_Documento"
                this.BuscarNum_Documento();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Le preguntamos al usuario si está seguro o no de eliminar un registro
                //Para eso usaremos una variable: opcion
                DialogResult Opcion;
                //Título: Sistema de Ventas.
                //Botones que voy a mostrar: OK, Cancel.
                //Icono: Questions, para mostrar una pregunta.
                Opcion = MessageBox.Show("Realmente desea eliminar los registros", "Sistemas de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                //Si el usuario tocó OK:
                if (Opcion == DialogResult.OK)
                {
                    //Declaro 2 variable:
                    //Variable Codigo: para enviar la llave primaria de la categoria que quiero eliminar:
                    string Codigo;
                    //Otra variable para recibir la respuesta si eliminó o no eliminó:
                    //La voy a inicializar en blanco:
                    string Rpta = "";

                    //Un bucle para que me verifique si están marcados los registros en mi checkbox
                    //Si están marcados, pasará a mi método eliminar de mi CapaNegocio...
                    //Y la CapaNegocio pasará al método eliminar de mi CapaDatos...
                    //Y mi CapaDatos lo pasará al procedimiento almacenado Eliminar de la DB.

                    //Rows: todas las filas
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        //El bucle está revisando fila por fila: row.Cells[0].Value
                        //Si la columna [0], que es el checkbox es true, por eso se convierte...
                        //... en Boolean
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Eliminar esa fila
                            //Columna [1] que es de la llave primaria:
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            //LLamo a mi clase NProveedor, y a su método Elimnar.
                            //Le envío mi variable Codigo pero como ésta variable es un string...
                            //... y el métod Elimninar está esperando un int lo convierto.
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                //Le envio el mensaje:
                                this.MensajeOk("Se eliminó correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }

                    //Para mostrar mi datalistado totalmente actualizado:
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Checked: está marcado:
            if (chkEliminar.Checked)
            {
                //La columna[0] va a ser visible: true:
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                //La columna[0] no va a ser visible: false:
                this.dataListado.Columns[0].Visible = false;
            }
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
            this.txtRazon_Social.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaro una variable para evaluar si se insertó o modificó:
                string rpta = "";
                //Voy a validar los datos. En éste caso, el campo Razón Social no puede estar vacío. Los otros también.
                //string.Empty = quiere decir que está vacía:
                if (this.txtRazon_Social.Text == string.Empty ||
                    this.txtNum_Documento.Text == string.Empty ||
                    this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    //Que el icono de error aparezca al costado de la caja de texto: txtNombre.
                    errorIcono.SetError(txtRazon_Social, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    //El usuario quiere realizar un registro:
                    if (this.IsNuevo)
                    {
                        //Se envían varios parámatros.
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(),
                                                   this.cbSector_Comercial.Text,
                                                   cbTipo_Documento.Text,
                                                   txtNum_Documento.Text,
                                                   txtDireccion.Text,
                                                   txtTelefono.Text,
                                                   txtEmail.Text,
                                                   txtUrl.Text);
                    }
                    else
                    {
                        //Se envían varios parámatros.
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text),
                                                 this.txtRazon_Social.Text.Trim().ToUpper(),
                                                 this.cbSector_Comercial.Text,
                                                 cbTipo_Documento.Text,
                                                 txtNum_Documento.Text,
                                                 txtDireccion.Text,
                                                 txtTelefono.Text,
                                                 txtEmail.Text,
                                                 txtUrl.Text);
                    }

                    //Esto es para la respuesta (rpta) de DProveedor, en el método insertar:
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Primero determino que la caja de texto no esté vacía:
            //Equals: para comparar un texto:
            if (!this.txtIdproveedor.Text.Equals(""))
            {
                //Si no está vacía activamos el botón Editar:
                this.IsEditar = true;
                //LLamamos a nuestro método botones:
                this.Botones();
                //Habilitamos todos los controles:
                this.Habilitar(true);
            }
            //Si la caja de texto está vacía:
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //"False" porque estamos cancelando todo
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //Dejamos en blanco nuestra caja de texto "Idproveedor"
            this.txtIdproveedor.Text = string.Empty;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si el indice de la columna si igual a dataLIstado en su columna Eliminar, los 
            //índices son iguales:
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                //Declaro una variable: ChkEliminar que es del tipo DataGridViewCheckBoxCell
                //para determinar cuál es el Chexbox selecciondado.
                //Datalistado.Rows: para ver la fila. En la celda (Cells) en este caso: Eliminar.
                //dataListado.Rows[e.RowIndex].Cells["Eliminar"] TODO este tipo de dato lo convierto...
                //... a este tipo de dato: (DataGridViewCheckBoxCell)
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                //Negamos primero:!
                //Convertimos a un valor ToBoolean todo lo que estè en ChkEliminar.
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Aquí va el código que me va a permitir devolver todos los valores de cada una 
            //de las columnas de mi datalistado a cada una de las cajas de texto:

            //Convierto, porque la caja de texto está esperando un string: Convert.ToString:
            //Convierto lo que tiene mi datalistado utilizando el método: CurrentRow, lo que
            //tiene la celda actual: cells. Entre corchetes le indico el nombre de la columna:
            //Finalmente le envío el valor que obtengo de esto: value:
            //Nombre del campo en nuestra base de datos:
            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtRazon_Social.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            this.cbSector_Comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector_comercial"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
