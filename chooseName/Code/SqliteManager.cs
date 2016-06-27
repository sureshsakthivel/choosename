using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Data.SQLite;
using System.IO;

namespace chooseName.Code
{
    public class SqliteManager
    {
        // Holds our connection with the database
        SQLiteConnection m_dbConnection;
        private static readonly string DB_PATH = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "data");
        //static void Main(string[] args)
        //{
        //    Program p = new Program();
        //}

        //public Program()
        //{
        //    createNewDatabase();
        //    connectToDatabase();
        //    createTable();
        //    fillTable();
        //    printHighscores();
        //}

        // Creates an empty database file
        public void createNewDatabase()
        {
            SQLiteConnection.CreateFile(DB_PATH + @"\MyDatabase.sqlite");
            
        }

        // Creates a connection with our database file.
        public void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source="+DB_PATH + @"\MyDatabase.sqlite;Version=3;");
           // m_dbConnection.ConnectionString = "Data Source=C:\\database\\info.db; Version=3;"; 

            m_dbConnection.Open();
        }

        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        public void createTable()
        {
            string sql = "create table highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        public void fillTable()
        {
            string sql = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // Writes the highscores to the console sorted on score in descending order.
        public void printHighscores()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }
    }
}
