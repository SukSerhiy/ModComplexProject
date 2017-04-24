using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDb
{
    public class Insert
    {
        static SqlConnection connection = null;

        static Insert()
        {
            string conStr = ConnectionInfo.connectionString;
            connection = new SqlConnection(conStr);
            connection.Open();
        }

        public static void InsertSprav_Acva(Sprav_Acva s)
        {
            string sql = string.Format("INSERT INTO Sprav_Acva(Name, Region, Descr) VALUES('{0}', '{1}', '{2}')", s.Name, s.Region, s.Descr);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertSprav_GAS(Sprav_GAS s)
        {
            string sql = string.Format("INSERT INTO Sprav_GAS(Type, Ent_num, Coord_X, Coord_Y, Coord_Z, Lat, Long, Depth) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", s.Type, s.Ent_num, s.Coord_X, s.Coord_Y, s.Coord_Z, s.Lat, s.Long, s.Depth);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertSprav_Objects(Sprav_Objects s)
        {
            string sql = string.Format("INSERT INTO Sprav_Objects(Symbol_id, Class_obj, Vid_obj, Type_obj, Descr) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", s.Symbol_id, s.Class_obj, s.Vid_obj, s.Type_obj, s.Descr);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertModel(Model m)
        {
            string sql = string.Format("INSERT INTO Model(Type, Name, Autor, Designer, DateUp, Descr, Path_FullDescr, Path_Exec) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})", m.Type, m.Name, m.Autor, m.Designer, m.DateUp, m.Descr, m.Path_FullDescr, m.Path_Exec);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertExperiment(Experiment m)
        {
            string sql = string.Format("INSERT INTO Experiment(Name_ex, Autor_ex, DatReg, Descr) VALUES('{0}', '{1}', '{2}', '{3}')", m.Name_ex, m.Autor_ex, m.DatReg, m.Descr);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertScene(Scene m)
        {
            string sql = string.Format("INSERT INTO Scene(Name, Id_exp, Id_acvatorii, DataReg, Descr) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", m.Name, m.Id_exp, m.Id_acvatorii, m.DataReg, m.Descr);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
