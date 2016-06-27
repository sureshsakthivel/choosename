using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Data.SQLite;
using System.IO;

namespace chooseName.Code.DAL
{
    public class SqliteManager
    {
        // Holds our connection with the database
        protected SQLiteConnection m_dbConnection;
        private static readonly string DB_PATH = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "data");

        // Creates an empty database file
        public void createNewDatabase()
        {
            if (!File.Exists(DB_PATH + @"\MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile(DB_PATH + @"\MyDatabase.sqlite");
            }
            
        }

        // Creates a connection with our database file.
        public void connectToDatabase()
        {
            if (m_dbConnection == null || (m_dbConnection!=null && m_dbConnection.State != System.Data.ConnectionState.Open))
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + DB_PATH + @"\MyDatabase.sqlite;Version=3;");

                m_dbConnection.Open();
            }
        }

        
        
        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        public void createTable()
        {
            connectToDatabase();
            string sql = string.Empty;
            SQLiteCommand command = null;
            if (!isTableExists(m_dbConnection, "user"))
            {
                sql = @"CREATE TABLE [user] (
                                [Id] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
                                [Name] VARCHAR(100)  UNIQUE NULL,
                                [EmailId] VARCHAR(100)  UNIQUE NULL,
                                [Password] VARCHAR(100)  NULL,
                                [Status] BOOLEAN  NULL,
                                [ActivationCode] VARCHAR(5)  NULL
                                )";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            if (!isTableExists(m_dbConnection, "numero"))
            {

                sql = @"CREATE TABLE [numero] (
                                [Id] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
                                [UserId] INTEGER NOT NULL,
                                [Name] VARCHAR(100)  UNIQUE NULL,
                                [NumeroPattern] VARCHAR(600)  UNIQUE NULL
                                )";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            if (!isTableExists(m_dbConnection, "pickname"))
            {
                sql = @"CREATE TABLE [pickname] (
[Id] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[unId] INTEGER NOT NULL,
[Name] VARCHAR(100)  UNIQUE NULL,
[NumerlogyNumber] INTEGER NOT NULL)";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

            }
            m_dbConnection.Close();
        }

        public Boolean isTableExists(SQLiteConnection db, String tableName)
        {
           
            int count = 0;
            string sql = String.Format("SELECT COUNT(*) FROM sqlite_master WHERE type = '{0}' AND name = '{1}'", "table", tableName);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                count = Convert.ToInt32(reader[0]);
              
            }

            return (count > 0) ? true : false;
            
        }


        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        public void fillTable()
        {
            connectToDatabase();
            string sql = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();

            connectToDatabase();
            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();

            connectToDatabase();
            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        // Writes the highscores to the console sorted on score in descending order.
        public void printHighscores()
        {
            connectToDatabase();
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            reader.Close();
            m_dbConnection.Close();
        }
    }
}
