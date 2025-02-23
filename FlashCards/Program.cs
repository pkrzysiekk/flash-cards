

using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using Spectre.Console;
using FlashCards.Controllers;
using FlashCards.Views.Menus;

namespace FlashCards
{
    internal class Program
    {

        static void Main()
        {
            DbInitializer initializer = new();
            MainMenu main = new();
            main.Show();
            //DbController dbController = new DbController();
         

        }
    }
}
