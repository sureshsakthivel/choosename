using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chooseName.Code.Model ;
using System.Data.SQLite;
using System.IO;

namespace chooseName.Code.DAL
{
   
    public class ChosenNameDAL : ConnectionDAL 
    {
        public void Insert(ChosenName chosenName)
        {
            try
            {
                string sql = "insert into chosenname (unId,Name,NumerlogyNumber) values (" + chosenName.UnId + ",'" + chosenName.Name + "'," + chosenName.NumerlogyNumber + ")";
                connectToDatabase();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
            }
            catch (SQLiteException ex)
            {
                throw;
            }
        }

        public List<ChosenName> Search(int unId = 0)
        {
            try
            {
                string sql = "select * from chosenname";
                if (unId > 0)
                    sql += " where unId=" + unId;
                connectToDatabase();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<ChosenName> names = GetList(reader);
                reader.Close();
                return names;
            }
            catch (SQLiteException ex)
            {
                throw;

            }

        }

        private List<ChosenName> GetList(SQLiteDataReader reader)
        {
            List<ChosenName> names = new List<ChosenName>();
            while (reader.Read())
            {
                names.Add(new ChosenName(Convert.ToInt32(reader["unId"]), Convert.ToInt32(reader["uId"]), Convert.ToString(reader["name"]), Convert.ToInt32(reader["NumerlogyNumber"])));
            }
            return names;

        }
    }
}