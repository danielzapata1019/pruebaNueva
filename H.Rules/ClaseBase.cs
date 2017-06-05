using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace H.Rules
{
    public class ClaseBase
    {

        #region Propiedades

        private string _QuerySQL = "";
        private String _UsuarioLogueado = "Anonimo";

        //datatable generico
        DataTable _Dtg = new DataTable();

        //SQLSERVER

        private string _BaseSQLServer = "";
        private int _TimeOutSQLServer = 15;//tiempo por defecto

        private string BaseSQLServer
        {
            get
            {
                return _BaseSQLServer;
            }
            set
            {
                _BaseSQLServer = value;
            }
        }

        private int TimeOutSQLServer
        {
            get
            {
                return _TimeOutSQLServer;
            }
            set
            {
                _TimeOutSQLServer = value;
            }
        }

        public DataTable Dtg
        {
            get
            {
                return _Dtg;
            }
            set
            {
                value = new DataTable();
                _Dtg = value;
            }
        }

        #endregion

        #region Metodos Privados
        protected void SQLGet(string SQL)
        {
            H.Data.SQLServer oSQL=new H.Data.SQLServer();
            if(BaseSQLServer !="")
            {
                oSQL.Base = BaseSQLServer;
            }
            oSQL.TimeOut = TimeOutSQLServer;
            _Dtg = oSQL.ExecuteQ(SQL);
        }

        protected void SQL_SET(string SQL)
        {
            H.Data.SQLServer oSQL = new H.Data.SQLServer();
            if (BaseSQLServer != "")
            {
                oSQL.Base = BaseSQLServer;
            }
            oSQL.TimeOut = TimeOutSQLServer;
            _Dtg = oSQL.ExecuteQ(SQL);
        }
        #endregion

    }
}
