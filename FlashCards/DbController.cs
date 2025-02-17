using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.Data.SqlClient;

namespace FlashCards
{
    public class DbController
    {
        private string _connectionString;
        public DbController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            InitializeDB();


        }

        private void InitializeDB()
        {
            if (_connectionString == null)
            {
                throw new Exception("No connection string!");
            }
            // Połączenie z instancją LocalDB, ale bez bazy danych
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string createDbQuery = @"
         IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Flashcards')
 BEGIN
     CREATE DATABASE Flashcards;
	USE Flashcards
	CREATE TABLE stacks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE cards (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name1 NVARCHAR(255) NOT NULL,
    Name2 NVARCHAR(255) NOT NULL,
    StackId INT NOT NULL,
    CONSTRAINT FK_cards_stacks FOREIGN KEY (StackId) REFERENCES stacks(Id) ON DELETE CASCADE
);

CREATE TABLE sessions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Score INT NOT NULL,
    Date SMALLDATETIME NOT NULL,
    StackId INT NOT NULL,
    CONSTRAINT FK_sessions_stacks FOREIGN KEY (StackId) REFERENCES stacks(Id) ON DELETE CASCADE
);
END;
        ";
             

                    using (SqlCommand command = new SqlCommand(createDbQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }




        }

    }
}
