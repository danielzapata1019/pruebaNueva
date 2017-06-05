using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace H.Data
{
    public class SQLServer
    {
        private int _TimeOut = 15;
        private string _Base = "Default";
        SqlConnection _cnn = new SqlConnection();
        SqlCommand _cmd = new SqlCommand();
        SqlDataAdapter _da = new SqlDataAdapter();
        SqlParameterCollection _pc = new SqlParameterCollection();
        OleDbConnection _OleDBcnn = new OleDbConnection();

        #region Propiedades
        
        public int TimeOut
        {
            get
            {
                return _TimeOut;
            }
            set
            {
                _TimeOut = value;
            }
        }

        public string Base
        {
            get
            {
                return _Base;
            }
            set
            {
                _Base = value;
            }
        }

        public string Cadena
        {
            get
            {
                switch(_Base)
                {
                    case "Default":
                        return H.Data.Properties.Settings.Default.Local;
                    default :
                        return "";
                }
            }
        }

        #endregion
        #region MetodosPrivados

       private void abrirBase(string ruta="")
        {
            _cnn.ConnectionString = Cadena;
            _cnn.Open();
        }

       private void cerrarBase()
       {
           if (_cnn.State == ConnectionState.Open)
           {
               _cnn.Close();
           }else if(_OleDBcnn.State==ConnectionState.Open){
               _cnn.Close();
           }
           
       }
        #endregion

        #region metodosPublicos

       public DataTable ExecuteQ(String SQL)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlDataAdapter da = new SqlDataAdapter(SQL, _cnn);
               abrirBase();
               da.SelectCommand.CommandTimeout = TimeOut;
               da.Fill(dt);
               return dt;

           }
           finally
           {
               cerrarBase();
           }
           
       }

       public void ExecuteNQ(String SQL)
       {
           try
           {
               abrirBase();
               _cmd.Connection = _cnn;
               _cmd.CommandText = SQL;
               _cmd.CommandTimeout = TimeOut;
               _cmd.ExecuteNonQuery();

           }
           finally
           {
               cerrarBase();
           }

       }
        #endregion

    }
}
