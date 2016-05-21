using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
namespace Emoticon2TapAPI.Models
{
    public class DataHelper
    {
        
        public static SqlConnection InitConnection ()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ScoreConnection"].ToString());
            conn.Open();
            return conn;
        }

        public static List<Score> SelectAllScore ()
        {
            List<Score> list = new List<Score>();
            string selectCmd = "select * from tbScore";
            SqlCommand cmd = new SqlCommand(selectCmd, InitConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                list.Add(new Score(Convert.ToInt16(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
            }
            return list;
        }

        public static void InsertScore(Score score) {
            string insertcmd = "insert into tbScore values("+score.score+", '"+score.Player+"', '"+score.datetime+"')";
            SqlCommand cmd = new SqlCommand(insertcmd, InitConnection());
            cmd.ExecuteNonQuery();
            
        }
    }
}