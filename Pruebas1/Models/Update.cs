using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DataBase;
using System.Reflection;


namespace Pruebas1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Update
    {
        [MaxLength(140)]
        public string Status { get; set; }
        public string Date { get; set; }
        public int ID { get; set; }

        public static List<Update> GetAll()
        {
            

            string query = "select * from update";
            DB db = new DB(query);
            DataTable dt = db.ObtenerTabla();
            List<Update> updates = new List<Update>();
            var fields = typeof(Update).GetFields();
            int i = 0;

            foreach (DataRow dr in dt.Rows)
            {
                var ob = Activator.CreateInstance<Update>();
                ob.Status = dt.Rows[i].ItemArray[0].ToString().Trim();
                ob.Date = dt.Rows[i][1].ToString().Trim();
                ob.ID = Convert.ToInt32(dt.Rows[i][2]);
                i++;
                updates.Add(ob);
            }

            return updates;
        }

        public static Update Buscar(int id)
        {
            string query;
            DB db;
            DataTable dt;
            Update update=new Update();

            query = "select * from update where id=?";
            db = new DB(query).Add("id",id);
            dt = db.ObtenerTabla();
            update.Status = dt.Rows[0][0].ToString();
            update.Date = dt.Rows[0][1].ToString();
            update.ID = Convert.ToInt32(dt.Rows[0][2]);
            return update;
        }

        public static Update Actualizar(Update update,int id)
        {
            string query;
            DB db;

            query = "update update set status=?,date=? where id=?";
            db = new DB(query).Add("status", update.Status).Add("date",update.Date).Add("id",update.ID).Ejecutar();
            update=Buscar(id);
            return update;
        }

        public static Update Insertar(Update update)
        {
            string query;
            int id;
            DB db;

            query = "insert into update values (?,?,?)";
            id = update.ID;
            db = new DB(query).Add("status",update.Status).Add("date",update.Date).Add("id",id).Ejecutar();
            update = Buscar(id);
            return update;
        }

        public static void Eliminar(int id)
        {
            string query;
            DB db;

            query = "delete from update where id=?";
            db = new DB(query).Add("id",id).Ejecutar();
        }

    }
}