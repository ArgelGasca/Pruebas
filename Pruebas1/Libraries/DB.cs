using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Xml.Serialization;

namespace DataBase
{
    public class DB
    {
        OleDbConnection conn = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=C:\\Users\\Argel\\Documents\\Visual FoxPro Projects");
        public OleDbCommand Cmd { get; set; }
        public DataTable Dt { get; set; }

        public DB(string query)
        {
            Cmd = new OleDbCommand(query, conn);
        }

        public DB(string query,string p1,int v1)
        {
            Cmd = new OleDbCommand(query, conn);
            Cmd.Parameters.AddWithValue(p1, v1);
        }

        public DB Add(string nombre,string val)
        {
            Cmd.Parameters.AddWithValue(nombre, val);
            return this;
        }

        public DB Add(string nombre, int val)
        {
            Cmd.Parameters.AddWithValue(nombre, val);
            return this;
        }

        public DB Ejecutar()
        {
            conn.Open();
            Cmd.ExecuteNonQuery();
            conn.Close();
            return this;
        }

        public DataTable ObtenerTabla()
        {
            DataTable dt=new DataTable();
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(Cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

    }
}