using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//LLamo a la CapaNegocio para comunicarme con sus métodos:
using CapaNegocio;

namespace CapaPresentacion
{
    //CUANDO SELECCIONE UNA CATEGORÍA DE MI DATALISTADO HACIENDO DOBLECLIC, ÉSTA CATEGORÍA (SU CÓDIGO Y...
    //... SU NOMBRE) SE DEBE ENVIAR AUTOMÁTICAMENTE A LAS CAJAS DE TEXTO RESPECTIVAS DE MI FRM MANTENIMIENTO DE ARTÍCULOS
    public partial class frmVistaCategoria_Articulo : Form
    {
        public frmVistaCategoria_Articulo()
        {
            InitializeComponent();
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

        private void frmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            //Para mostrar las categorías en un primer momento:
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //LLamo a mi instancia que cree en mi frmArticulo:
            frmArticulo form = frmArticulo.GetInstancia();

            string par1, par2;

            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);

            //El método "setCategoria" está esperando 2 parámetros:
            form.setCategoria(par1, par2);
            //Después de enviar esos 2 parámetros, oculto éste formulario:
            this.Hide();
        }
    }
}
