using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDb
{
    public class Update
    {
        static SqlConnection connection = null;

        static Update()
        {
            string conStr = ConnectionInfo.connectionString;
            connection = new SqlConnection(conStr);
            connection.Open();
        }

        public static void UpdateSprav_Acva(Sprav_Acva s)
        {
            string sql = string.Format("UPDATE Sprav_Acva SET Name='{0}', Region='{1}', Descr='{2}' WHERE Id_acv='{3}'", s.Name, s.Region, s.Descr, s.Id_acv);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateSprav_GAS(Sprav_GAS s)
        {
            string sql = string.Format("UPDATE Sprav_GAS SET Type='{0}', Ent_num='{1}', Coord_X='{2}', Coord_Y='{3}', Coord_Z='{3}', Lat='{4}', Long='{5}', Depth='{6}' WHERE Id_GAS='{7}'", s.Type, s.Ent_num, s.Coord_X, s.Coord_Y, s.Coord_Z, s.Lat, s.Long, s.Depth, s.Id_GAS);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateSprav_Objects(Sprav_Objects s)
        {
            string sql = string.Format("UPDATE Sprav_Objects SET Symbol_id='{0}', Class_obj='{1}', Vid_obj='{2}', Type_obj='{3}', Descr='{4}' WHERE Id_obj='{5}'", s.Symbol_id, s.Class_obj, s.Vid_obj, s.Type_obj, s.Descr, s.Id_obj);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateModel(Model m)
        {
            string sql = string.Format("UPDATE Model SET Type='{0}', Name='{1}', Autor='{2}', Designer='{3}', DateUp='{4}', Descr='{5}', Path_FullDescr='{6}', Path_Exec='{7}' WHERE Id_GAS='{8}'", m.Type, m.Name, m.Autor, m.Designer, m.DateUp, m.Descr, m.Path_FullDescr, m.Path_Exec, m.Id_mod);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateExperiment(Experiment m)
        {
            string sql = string.Format("UPDATE Experiment SET Name_ex='{0}', Autor_ex='{1}', DatReg='{2}', Descr='{3}' WHERE Id_ex='{4}'", m.Name_ex, m.Autor_ex, m.DatReg, m.Descr, m.Id_ex);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateScene(Scene m)
        {
            string sql = string.Format("UPDATE Scene SET Name='{0}', Id_exp='{1}', Id_acvatorii='{2}', DataReg='{3}', Descr='{4}' WHERE Id_sc='{5}'", m.Name, m.Id_exp, m.Id_acvatorii, m.DataReg, m.Descr, m.Id_sc);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
