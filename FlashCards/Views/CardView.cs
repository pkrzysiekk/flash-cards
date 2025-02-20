using FlashCards.Models.FlashCards;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public static class CardView
    {
        public static void ShowCollection(IEnumerable<FlashCardDTO> cardsList)
        {
            foreach (var card in cardsList)
            {
                var table = new Table();
                table.AddColumn(card.Name1);
                table.AddRow(card.Name2);
                AnsiConsole.Write(table);
            }

        }
        
    }
}
