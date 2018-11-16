using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregamos
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    //Cambiamos a pública:
    public class NIngreso
    {
        public static string Insertar(int idtrabajador, 
                                      int idproveedor, 
                                      DateTime fecha,
                                      string tipo_comprobante, 
                                      string serie, 
                                      string correlativo, 
                                      decimal igv,
                                      string estado, 
                                      DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            //Vamos a recibir todos los detalles de éste parámetro: dtDetalles:
            //Creo un objeto: se va a llamar: detalles.
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            //Voy recorriendo fila por fila. Creo un objeto del tipo DataRow, se llama row. Va recorriendo...
            //... del parámetro dtDetalles todas las filas que tenga.
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                //detalles es una lista de todos esos objetos de DDetalle_Ingreso.
                //Digo detalles y agrego (Add) ese objeto (detalle)
                detalles.Add(detalle);
            }
            //Le envío primero el objeto y luego los detalles.
            //Quién lo recibe? el objeto Insertar de mi clase DIngreso
            return Obj.Insertar(Obj, detalles);
        }

        //Método Anular
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        //Método MostrarDetalle
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
