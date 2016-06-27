using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chooseName.Code.Model;
using System.Data.SQLite;
using System.IO;
namespace chooseName.Code.DAL
{
    public class NumeroDAL : ConnectionDAL
    {
        public void Insert(Numero numero)
        {
            try
            {
                string sql = "insert into Numero (Id,Name,NumeroPattern) values (" + numero.Id + ",'" + numero.Name + "','" + numero.NumeroPattern + "')";
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