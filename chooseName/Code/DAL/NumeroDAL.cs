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
                string sql = "insert into Numero (Id,UserId,Name,NumeroPattern) values (" + numero.Id + "," + numero.UserId +",'" + numero.Name + "','" + numero.NumeroPattern + "')";
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
        public List<Numero> Search(int userId)
        {
            try
            {
                string sql = "select * from Numero where userid=" + userId;
 
                connectToDatabase();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<Numero> numeros = GetList(reader);
                reader.Close();
                return numeros;
            }
            catch (SQLiteException ex)
            {
                throw;
            }

        }

        public Numero Fetch(int Id)
        {
            try
            {
                string sql = "select * from Numero where Id=" + Id;

                connectToDatabase();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<Numero> numeros = GetList(reader);
                reader.Close();
                return (numeros != null && numeros.Count > 0) ? numeros.FirstOrDefault() : null;
            }
            catch (SQLiteException ex)
            {
                throw;
            }

        }

        private List<Numero> GetList(SQLiteDataReader reader)
        {
            List<Numero> numeros = new List<Numero>();
            while (reader.Read())
            {
                numeros.Add(new Numero(
                   Convert.ToInt32(reader["Id"]),
                    Convert.ToInt32(reader["UserId"]),
                  Convert.ToString(reader["name"]),
                   Convert.ToString(reader["numeropattern"]) ));

            }
            return numeros;

        }
    }
}