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

        //Método Mostrar todos los registros de la tabla cateogoría:
        private void Mostrar()
        {
            //LLamo a mi clase NCategoria, donde está mi procedimiento: Mostrar, para que me envíe...
            //... ciertos valores.
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Métod BuscarNombre.
        private void BuscarNombre()
        {
            //LLamo a mi clase NCategoria, donde está mi procedimiento: BuscarNombre, para que me envíe...
            //... ciertos valores.
            //BuscarNombre, está esperando un parámetro: la caja de texto: txtBuscar
            //Y obtengo el texto con su propiedad: .Text
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
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
            //LLamo a mi método BuscarNombre:
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Cada vez que el usuario escriba una letra o borre, se valla actualizando el datalistado:
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
                if(this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    //Que el icono de error aparezca al costado de la caja de texto: txtNombre.
                    erroricono.SetError(txtNombre,"Ingrese un Nombre");
                }
                else
                {
                    //El usuario quiere realizar un registro:
                    if (this.IsNuevo)
                    {
                        //Se envían 2 parámatros: txtNombre, para enviar el nombre. Y descripción.
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NCategoria.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                                                   this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        //Se envían 3 parámatros.
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NCategoria.Editar(Convert.ToInt32(this.txtIdcategoria.Text), 
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Aquí va el código que me va a permitir devolver todos los valores de cada una 
            //de las columnas de mi datalistado a cada una de las cajas de texto:

            //Convierto, porque la caja de texto está esperando un string: Convert.ToString:
            //Convierto lo que tiene mi datalistado utilizando el método: CurrentRow, lo que
            //tiene la celda actual: cells. Entre corchetes le indico el nombre de la columna:
            //Finalmente le envío el valor que obtengo de esto: value:
            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Primero determino que la caja de texto no esté vacía:
            //Equals : para comparar un texto:
            if(!this.txtIdcategoria.Text.Equals(""))
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
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //False: para deshabilitar todas las cajas de texto y dejarlas en sólo lectura:
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Checked: está marcado:
            if(chkEliminar.Checked)
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si el indice de la columna si igual a dataLIstado en su columna Eliminar, los 
            //índices son iguales:
            if (e.ColumnIndex==dataListado.Columns["Eliminar"].Index)
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
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        //El bucle está revisando fila por fila: row.Cells[0].Value
                        //Si la columna [0], que es el checkbox es true, por eso se convierte...
                        //... en Boolean
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Eliminar esa fila
                            //Columna [1] que es de la llave primaria:
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            //LLamo a mi clase NCategoria, y a su método Elimnar.
                            //Le envío mi variable Codigo pero como ésta variable es un string...
                            //... y el métod Elimninar está esperando un int lo convierto.
                            Rpta = NCategoria.Eliminar(Convert.ToInt32(Codigo));

                            if(Rpta.Equals("OK"))
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

    }
}
