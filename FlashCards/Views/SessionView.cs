﻿using FlashCards.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public static class SessionView
    {
        public static void ShowSessions(IEnumerable<SessionBO> sessions)
        {
            var table = new Table();
            table.AddColumn("Date");
            table.AddColumn("Score");
            table.AddColumn("MaxScore");
            table.Border(TableBorder.HeavyEdge);

            foreach (var session in sessions)
            {
                table.AddRow($"{session.Date}", $"{session.Score}", $"{session.MaxScore}");
               
            }
            AnsiConsole.Write(table);

        }
    }
}
