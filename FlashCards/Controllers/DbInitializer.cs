using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.Data.SqlClient;
using FlashCards.Models;

namespace FlashCards.Controllers
{
    public class DbInitializer : DbController
    {
        private string? serverConnectionString;
        public DbInitializer()
        {
            serverConnectionString = ConfigurationManager.ConnectionStrings["ServerConnectionString"].ConnectionString;
            InitializeDB();

        }

        private void InitializeDB()
        {
            if (serverConnectionString == null)
            {
                throw new Exception("No connection string!");
            }
            

            using (SqlConnection connection = new SqlConnection(serverConnectionString))
            {
                try
                {
                    connection.Open();
                    string createDbQuery = @"
         IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Flashcards')
 BEGIN
     CREATE DATABASE Flashcards;
	
END;
        ";
                    string createDbTables = @"
 USE Flashcards;

-- Sprawdzenie i utworzenie tabeli 'stacks'
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'stacks')
BEGIN
    CREATE TABLE stacks (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) UNIQUE NOT NULL
    );
END;

-- Sprawdzenie i utworzenie tabeli 'cards'
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'cards')
BEGIN
    CREATE TABLE cards (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name1 NVARCHAR(255) NOT NULL,
        Name2 NVARCHAR(255) NOT NULL,
        StackId INT NOT NULL,
        CONSTRAINT FK_cards_stacks FOREIGN KEY (StackId) REFERENCES stacks(Id) ON DELETE CASCADE
    );
END;

-- Sprawdzenie i utworzenie tabeli 'sessions'
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'sessions')
BEGIN
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
                    using (SqlCommand command = new SqlCommand(createDbTables, connection))
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
