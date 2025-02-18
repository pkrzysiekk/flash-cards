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
    public  class StackController : DbController
    {
        public void Insert( StackBO stack)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = " INSERT INTO stacks (Name) VALUES (@Name);";
                try
                {
                    connection.Execute(sql, stack);
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    AnsiConsole.MarkupLine("[Red] This stack already exists![/]");

                    return;
                }
                AnsiConsole.MarkupLine("[Green] Added succesfully [/]");
            }
        }

        public IEnumerable<StackDTO> GetAll()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT Name FROM  stacks";
                var stackList=connection.Query<StackDTO>(sql).ToList();
                return stackList;
            }
        }
       
    }
}
