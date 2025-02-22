using Dapper;
using FlashCards.Models;
using FlashCards.Models.Stack;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Controllers
{
    public class SessionController : DbController
    {
        public void Insert(StackBO stack,SessionBO session)
        {
            session.StackId = stack.Id;
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO sessions (Score,MaxScore,Date,StackId)" +
                    "VALUES (@Score,@MaxScore,@Date,@StackId)";
                try
                {
                    connection.Execute(sql, session);
                }
                catch (Exception ex) 
                {
                    AnsiConsole.MarkupLine(ex.Message);
                }
            }
        }

        public IEnumerable<SessionBO>? GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM sessions";
                try
                {
                    return connection.Query<SessionBO>(sql).ToList();
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[Red]{ex.Message}[/]");
                    return null;
                }
            }
        }
    }
}
