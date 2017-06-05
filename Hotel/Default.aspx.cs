using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Hotel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void cargarCombos()
        {
            H.Rules.Usuario oUsuario = new H.Rules.Usuario();
            oUsuario.getUser();
            ddlCiudad.DataSource = oUsuario.Dtg;
            ddlCiudad.DataValueField = "IdUsuario";
            ddlCiudad.DataTextField = "Usuario";
            ddlCiudad.DataBind();


            //Cargamos los Tipos de Usuario
            ddlTipoId.Items.Clear();
            ListItem lst = new ListItem("Add New", "0");
            ListItem lst1 = new ListItem("Add New", "0");
            ddlTipoId.Items.Insert(ddlTipoId.Items.Count - 1, lst);
            ddlTipoId.Items.Insert(ddlTipoId.Items.Count - 1, lst1);
            

        }
    }


}