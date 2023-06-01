using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    /// <summary>
    /// @author Devora Ginsberger
    /// connecting and getting data from the database
    /// </summary>
    internal class DatabaseConn
    {
        private SqlConnection conn;
        public SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=; Initial Catalog=Contacts; Integrated Security=SSPI");
        }
        public void Connect()
        {
            try
            {
                conn = GetConnection();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Disconnect()
        {
            try
            {
                if(conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable SelectDt(ref SqlCommand cmd)
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(dt);
            return dt;
        }
        public int Execute(ref SqlCommand cmd)
        {
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                int rowAffwcted = cmd.ExecuteNonQuery();
                return rowAffwcted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
