﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chooseName.Code.Model;
using System.Data.SQLite;
using System.IO;
namespace chooseName.Code.DAL
{
    public class ConnectionDAL
    {
        protected SQLiteConnection m_dbConnection;
        private static readonly string DB_PATH = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "data");
        public void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + DB_PATH + @"\MyDatabase.sqlite;Version=3;");
            // m_dbConnection.ConnectionString = "Data Source=C:\\database\\info.db; Version=3;"; 

            m_dbConnection.Open();
        }
    }
    public class UserDAL : ConnectionDAL
    {
        public void Insert(User user)
        {
            try
            {
                string sql = "insert into user (Name,EmailId,Password,Status,ActivationCode) values ('" + user.Name + "','" + user.EmailId + "','" + user.Password + "'','" + user.Status + "',null )";

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