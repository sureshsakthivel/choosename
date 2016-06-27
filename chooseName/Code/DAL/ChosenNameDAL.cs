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
                string sql = "insert into chosenname (unId,Name,NumerlogyNumber) values (" + chosenName.unId + ",'" + chosenName.Name + "'," + chosenName.NumerlogyNumber + ")";
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
    }
}