using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    /// <summary>
    /// @author Devora Ginsberger
    /// Methods to do on the contact list
    /// </summary>
    internal class Contact
    {
        public DataTable SelectContactsList()
        {
            try
            {
                DatabaseConn dbconn = new DatabaseConn();
                dbconn.Connect();
                SqlCommand cmd = new SqlCommand("SelectContactsList");
                DataTable dt = dbconn.SelectDt(ref cmd);
                dbconn.Disconnect();
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool AddContact(string lastName, string firstName, string phoneNumber)
        {
            try
            {
                DatabaseConn dbconn = new DatabaseConn();
                dbconn.Connect();
                SqlCommand cmd = new SqlCommand("AddContact");
                SqlParameter param;
                param = cmd.Parameters.AddWithValue("@lastName", lastName);
                param = cmd.Parameters.AddWithValue("@firstName", firstName);
                param = cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                int rowAffwcted = dbconn.Execute(ref cmd);
                dbconn.Disconnect();
                return rowAffwcted > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteContact(string lastName, string firstName)
        {
            try
            {
                DatabaseConn dbconn = new DatabaseConn();
                dbconn.Connect();
                SqlCommand cmd = new SqlCommand("DeleteContact");
                SqlParameter param;
                param = cmd.Parameters.AddWithValue("@lastName", lastName);
                param = cmd.Parameters.AddWithValue("@firstName", firstName);
                int rowAffwcted = dbconn.Execute(ref cmd);
                dbconn.Disconnect();
                return rowAffwcted > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool UpdatePhoneNumber(string lastName, string firstName, string phoneNumber)
        {
            try
            {
                DatabaseConn dbconn = new DatabaseConn();
                dbconn.Connect();
                SqlCommand cmd = new SqlCommand("UpdatePhoneNumber");
                SqlParameter param;
                param = cmd.Parameters.AddWithValue("@lastName", lastName);
                param = cmd.Parameters.AddWithValue("@firstName", firstName);
                param = cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                int rowAffwcted = dbconn.Execute(ref cmd);
                dbconn.Disconnect();
                return rowAffwcted > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable SearchContactByName(string name)
        {
            try
            {
                DatabaseConn dbconn = new DatabaseConn();
                dbconn.Connect();
                SqlCommand cmd = new SqlCommand("SearchContactByName");
                SqlParameter param;
                param = cmd.Parameters.AddWithValue("@name", name);
                DataTable dt = dbconn.SelectDt(ref cmd);
                dbconn.Disconnect();
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
