using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example7
{
    public partial class Productos : System.Web.UI.Page
    {
        Conector conector = new Conector();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                llenar_cmbCategoria();
            }

        }
        public void llenar_cmbCategoria()
        {
            string SQL = "";
            SQL += "SELECT DISTINCT  ct.CodigoCategoria, ct.Nombre ";
            SQL += "FROM Categoria as ct ";
            SQL += "INNER JOIN Producto AS pd ON ct.CodigoCategoria = pd.CodigoCategoria ";
            SQL += "INNER JOIN Venta AS vn ON pd.CodigoProducto = vn.CodigoProducto ";
            SQL += "WHERE YEAR(vn.Fecha)=2019 ";

            DataTable categoria = conector.obtener_resultados(SQL);

            cmbCategoria.DataSource = categoria;
            cmbCategoria.DataTextField = "Nombre";
            cmbCategoria.DataValueField = "CodigoCategoria";
            cmbCategoria.DataBind();

            ListItem item = new ListItem();

            item.Text = "";
            item.Value = "0";
            item.Selected = true;


            cmbCategoria.Items.Insert(0, item);

        }

        protected void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigocategoria = "";
            codigocategoria = cmbCategoria.SelectedValue;


            string SQL = "";
            SQL += "SELECT  pd.Nombre ";
            SQL += "FROM Producto AS pd ";
            SQL += "INNER JOIN Venta AS vn ";
            SQL += "ON pd.CodigoCategoria =vn.CodigoProducto ";
            SQL += "Where YEAR(vn.Fecha)=2019 AND CodigoCategoria = " + codigocategoria;


            DataTable productos = conector.obtener_resultados(SQL);

            gvProductos.DataSource = productos;
            gvProductos.DataBind();


        }
    }
}