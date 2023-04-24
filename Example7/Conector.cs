using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Example7
{
    public class Conector
    {

        public static string connection = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        private SqlConnection cnn = null;
        public string comilla = "'";

        private void conectar()
        {
            try
            {
                cnn = new SqlConnection(connection);
                cnn.Open();
            }
            catch (Exception ex)
            {

            }

        }

        public void desconectar()
        {
            try
            {
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception ex)
            {

            }
        }



        private DataSet consulta_dataset(string SQL)
        {
            this.conectar();
            DataSet ds = null;
            try
            {
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            this.desconectar();
            return ds;
        }



        public DataTable obtener_resultados(string SQL)
        {
            this.conectar();
            DataTable dt = null;
            try
            {
                dt = consulta_dataset(SQL).Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
            }
            this.desconectar();
            return dt;
        }
    }
}
