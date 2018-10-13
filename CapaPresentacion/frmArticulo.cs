using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Acceder a Capa Negocio:
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmArticulo : Form
    {
        //2 Variables. Me van a indicar si voy a registrar un artículo o lo voy a editar.
        private bool IsNuevo = false;
        private bool IsEditar = false;

        //Variable que va a hacer una instancia a frmArticulo
        private static frmArticulo _Instancia;

        public static frmArticulo GetInstancia()
        {
            //No tengo aún una instancia:
            if(_Instancia == null)
            {
                //Si no tengo instancia, la creo:
                _Instancia = new frmArticulo();
            }

            //En caso contrario, envío la instancia que ya tengo.
            //Como es una función lo que estoy implementando (GetInstancia()) retorno dicha instancia:
            return _Instancia;
        }

        //Otro método para enviar los valores recibidos a la caja de texto de txtIdcategoria
        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdcategoria.Text = idcategoria;
            //En mi caja de texto "txtCategoria" será igual al "nombre" que esté recibiendo para asignarle...
            //... a la caja de texto
            this.txtCategoria.Text = nombre;
        }


        //Constructor:
        public frmArticulo()
        {
            InitializeComponent();
            //Mostrar el mensaje de ayuda. Tenemos un control: ttMensaje
            //LLamamos a su método: SetToolTip
            //Parámetros: txtNombre que es el textbox. También el texto a mostrar.
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Artículo");
            
            //Cuando el usuario ponga el mouse sobre pxImagen va a salir un mensaje: "seleccione al imagen del artículo"
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la Imagen del Artículo");

            //Cuando ponga el mouse sobre el combobox: cbIdpresentacion
            this.ttMensaje.SetToolTip(this.cbIdpresentacion, "Seleccione la Presentación del Artículo");

            //Cuando el usuario ponga el mouse sobre caja de texto Categoria
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la Categoria del Artículo");

            //Ocultamos el primer control: txtIdcategoria
            this.txtIdcategoria.Visible = false;

            //Hacemos que la caja de texto Categoria sea de sólo lectura, para que el usuario no pueda modificar
            this.txtCategoria.ReadOnly = true;

            //LLamo a mi método Llenar Combo Presentacion, para que cuando se ejecute nuestro formulario...
            //... se llene con todas las presentaciones:
            this.LLenarComboPresentacion();
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
            this.txtCodigo.Text = string.Empty;
            //Caja de texto: txtNombre.
            //Para dejar en blanco: string.Empty.
            this.txtNombre.Text = string.Empty;
            //Caja de texto: txtDescripcion.
            this.txtDescripcion.Text = string.Empty;
            //Caja de texto: txtIdcategoria.
            this.txtIdcategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;

            //Propiedad: Image.
            //Le enviamos: global::CapaPresentacion.
            //Llamamos a la carpeta: Resources.
            //LLamamos al archivo file, que es un archivo transparente para enviar a la base de datos...
            //... cuando no se seleccione ningún artículo y ninguna imagen de ningún artículo...
            //... para ocupar menos espacion en la BD, ya que es una imagen .png transparente.
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        //Habilitar los controles de los formularios:
        private void Habilitar(bool valor)
        {
            //Este procedimiento va modificar las cajas de texto, para que estén habilitadas o
            //deshabilitadas.

            this.txtCodigo.ReadOnly = !valor;

            //ReadOnly: para hacerla de sólo lectura.
            //!Valor sería falso, negamos el valor que recibimos.  
            //Si recibimos true las cajas de texto van a estar habilitadas.
            //Si recibimos false, las cajas de texto van a estar deshabilitadas.
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;

            //Se envia: "valor"  ya que las propiedades no son "ReadOnly" sino "Enable":
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdpresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;

            this.txtIdarticulo.ReadOnly = !valor;
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
            //Oculto la columna: idarticulo [1]
            //El número o cantidades de columnas las puedo ver en spmostrar_articulo en sqlserver.
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //Columna 6: idcategoria:
            this.dataListado.Columns[6].Visible = false;
            //Columna 8: idpresentacion:
            this.dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar todos los registros de la tabla articulo:
        private void Mostrar()
        {
            //LLamo a mi clase NArticulo, donde está mi procedimiento: Mostrar, para que me envíe...
            //... ciertos valores.
            this.dataListado.DataSource = NArticulo.Mostrar();
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
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            //lo concatenamos con el total de registros, llamando a su métodos Rows (de filas)...
            //... y llamamos a su método count, para contar todas las filas.
            //Como: ataListado.Rows.Count, me devuelve un int y lo que queremos es un string...
            //... para eso usamos: Convert.ToString, para convertir todo a un string:
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para que llene el combobox con todas las presentaciones que están en la BD:
        private void LLenarComboPresentacion()
        {
            //A nuestro "cbIdpresentacion" en su método "DataSource" (para poder almacenar datos) voy a...
            //... hacer una instancia "NPresentacion", y llamo a su método "Mostrar()", éste último...
            //... devolverme todas las presentaciones que obtenga con mi método "Mostrar()"
            cbIdpresentacion.DataSource = NPresentacion.Mostrar();
            //Llamo a su propiedad "ValueMember" (Valor de los item) y entre comillas le indico que aqui me muestre el...
            //... "idpresentacion" porque así se llama el campo que estoy obteniendo.
            cbIdpresentacion.ValueMember = "idpresentacion";
            //Lo que quiero que se muestre aquí, es decir el "nombre" de la presentación:
            cbIdpresentacion.DisplayMember = "nombre";
        }


        private void frmArticulo_Load(object sender, EventArgs e)
        {
            //Para que se ubique en la parte superior izquierda:
            this.Top = 0;
            //Para que se ubique en la parte izquierda
            this.Left = 0;

            this.Mostrar();
            //Habilitar espera un parámetro: false. Para que salgan deshabilitados todos los controles:
            this.Habilitar(false);
            this.Botones();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Creamos un objeto que se llama "dialog" y hago una instancia "new OpenFileDialog()"
            //Así creamos nuestro cuadro de diálogo que se llama "dialog":
            OpenFileDialog dialog = new OpenFileDialog();

            //Creamos una variable "result" que será el resultado que obtengamos cuando mostremos el...
            //... cuadro de diálogo "ShowDialog()" en éste caso que se llama "dialog":
            DialogResult result = dialog.ShowDialog();

            //Si el usuario sí seleccionó una imagen = DialogResult.OK
            if(result == DialogResult.OK)
            {
                //El tamaño va a ser igual a un modo estrecho para que una imagen grande se adecue al...
                //... tamaño del PictureBox (pxImagen)
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                //LLamamos a la propiedad "Image" que va a obtener la imagen viene de una archivo "FromFile" y que el archivo...
                //... lo obtenga desde el cuadro de diálogo en éste caso "dialog.FileName" que es la...
                //... propiedad que obtiene el nombre del archivo:
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //El tamaño va a ser igual a un modo estrecho para que una imagen grande se adecue al...
            //... tamaño del PictureBox (pxImagen)
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            //Le enviamos la siguiente imagen cuando el usuario quiera limpiar. Le enviamos la imagen...
            //... file.png, que es la imagen totalmente vacía:
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Que llame al método: BuscarNombre():
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Para que la búsqueda se haga inmediatamente, cuando el usuario valla escribiendo:
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
                //No pueden estar vacías las siguientes cajas de texto:
                //Voy a validar los datos. En éste caso, el campo Nombre no puede estar vacío:
                //string.Empty = quiere decir que está vacía:
                //O caja de texto idcategoria "txtIdcategoria"
                //O caja de texto codigo "txtCodigo" 
                if (this.txtNombre.Text == string.Empty ||
                    this.txtIdcategoria.Text == string.Empty ||
                    this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    //Que el icono de error aparezca al costado de la caja de texto: txtNombre.
                    erroricono.SetError(txtNombre, "Ingrese un Valor");
                    //Que el icono de error aparezca al costado de la caja de texto: txtCodigo.
                    erroricono.SetError(txtCodigo, "Ingrese un Valor");
                    //Que el icono de error aparezca al costado de la caja de texto: txtCategoria.
                    erroricono.SetError(txtCategoria, "Ingrese un Valor");
                }
                else
                {
                    //Si las cajas de texto no están vacías procedemos a Guardar o Editar
                    //Recordemos que tenemos que enviar una imagen y la imagen está en el PictureBox entonces
                    //... usaremos un stream como buffer
                    //Hacemos una instancia: new System.IO.MemoryStream()
                    //Un objeto: "ms" para que haga la instancia a toda esta clase: System.IO.MemoryStream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    //Después guardamos la imagen en el bufer:
                    //Le enviamos unos parámetros: el objeto "ms" y la indicación del formato "ImageFormat.Png"
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    //Declaro una variable "imagen" que va a ser igual al objeto "ms" y llamo a su métod0...
                    //... "GetBuffer()" para obtener lo que tengo almacenado en el buffer:
                    byte[] imagen = ms.GetBuffer();
                    
                    //El usuario quiere realizar un registro:
                    if (this.IsNuevo)
                    {
                        //Se envían 6 parámatros. txtCodigo, para enviar el código, por ejemplo.
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NArticulo.Insertar(this.txtCodigo.Text,
                                                  this.txtNombre.Text.Trim().ToUpper(),
                                                  this.txtDescripcion.Text.Trim(),
                                                  imagen,
                                                  //Lo que obtengo en una caja de texto es un string y el...
                                                  //Idcategoria que estamos recibiendo en el NArticulo es..
                                                  //... un int, por lo que hay que convertir.
                                                  Convert.ToInt32(this.txtIdcategoria.Text),
                                                  //También convertimos a un int.
                                                  //Obtengo el código con qué propiedad? Propiedad...
                                                  //... "SelectedValue" para obtener el valor de mi índice elegido en mi ComboBox
                                                  Convert.ToInt32(this.cbIdpresentacion.SelectedValue));
                    }
                    else
                    {
                        //Se envían 7 parámatros.
                        //Como es un string: this.txtIdarticulo.Text, lo paso a un int: Convert.ToInt32
                        //Trim: para borrar los espacios en blanco.
                        //ToUpper: para convertir a mayúsculas.
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text),
                                                  this.txtCodigo.Text,
                                                  this.txtNombre.Text.Trim().ToUpper(),
                                                  this.txtDescripcion.Text.Trim(),
                                                  imagen,
                                                  //Lo que obtengo en una caja de texto es un string y el...
                                                  //Idcategoria que estamos recibiendo en el NArticulo es..
                                                  //... un int, por lo que hay que convertir.
                                                  Convert.ToInt32(this.txtIdcategoria.Text),
                                                  //También convertimos a un int.
                                                  //Obtengo el código con qué propiedad? Propiedad...
                                                  //... "SelectedValue" para obtener el valor de mi índice elegido en mi ComboBox
                                                  Convert.ToInt32(this.cbIdpresentacion.SelectedValue));
                    }

                    //Esto es para la respuesta (rpta) de DArticulo, en el método insertar:
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
            //Equals : para comparar un texto:
            if (!this.txtIdarticulo.Text.Equals(""))
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

            //Qué le envío al Idarticulo?:
            //Convierto, porque la caja de texto está esperando un string: Convert.ToString:
            //Convierto lo que tiene mi datalistado utilizando el método: CurrentRow, lo que
            //tiene la celda actual: cells. Entre corchetes le indico el nombre de la columna:
            //Finalmente le envío el valor que obtengo de esto: value:
            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            //Almacenamos la imagen en un buffer:
            //Convierto todo el dato obtenido a un tipo de dato byte: (byte[]):
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            //Como parámetro le enviamos toda la "imagenBuffer"
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            //Ahora usamos el MemoryStream para extraer la imagen:
            this.pxImagen.Image = Image.FromStream(ms);
            //Le decimos el modo en como se mostrará:
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            //["idcategoria"] es de nuestra consulta en sqlserver
            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria"].Value);
            //El idpresentacion está en un ComboBox: cbIdpresentacion
            //LLamamos a su propiedad "SelectedValue". Y qué seleccionamos? El "idpresentacion"
            this.cbIdpresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);

            this.tabControl1.SelectedIndex = 1;
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
                    //Variable Codigo: para enviar la llave primaria de la presentacion que quiero eliminar:
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
                            //LLamo a mi clase NArticulo, y a su método Elimnar.
                            //Le envío mi variable Codigo pero como ésta variable es un string...
                            //... y el método Elimninar está esperando un int lo convierto.
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            //Creamos un objeto del tipo "frmVistaCategoria_Articulo", será "form":
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            //Mostrar una ventana o formulario emergente:
            form.ShowDialog();
        }
    }
}
