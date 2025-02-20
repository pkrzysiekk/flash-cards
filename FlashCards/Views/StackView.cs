using FlashCards.Models.Stack;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public static class StackView
    {
        public static void ShowStacks(IEnumerable<StackDTO> stacks)
        {
            
            foreach (var stack in stacks) 
            {
                var table = new Table();
                table.AddColumn($"{stack.Name}");
                table.Border(TableBorder.DoubleEdge);
                AnsiConsole.Write(table);
            }
            
        }

        
    }
}
