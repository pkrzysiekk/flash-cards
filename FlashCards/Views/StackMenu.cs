using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public class StackMenu
    {
        private readonly string[] _stackMenuChoices = { "Add Stack", "See Stack", "Delete Stack","Exit" };


        private string GetUserChoice()
        {
            var menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[Purple]What would you want to do? [/]")
                .AddChoices(_stackMenuChoices)
                );
            return menuChoice;
        }
        public void Show()
        {
            while (true)
            {
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "Add Stack":
                        break;
                    case "See Stack":
                        break;
                    case "Delete Stack":
                        break;
                    case "Exit":
                        return;

                }
            }

        }
    }
}
