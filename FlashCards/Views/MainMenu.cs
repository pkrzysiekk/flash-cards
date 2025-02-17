using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public class MainMenu
    {
        private static string[] _choices= { "Menage Stacks", "Menage FlashCards", "Study", "View Study Sessions","Exit" };
        private StackMenu _stackMenu= new();
        public string GetUserChoice()
        {
            var menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("[Teal]What would you want to do? [/]")
               .AddChoices(_choices)
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
                    case "Menage Stacks":
                        _stackMenu.Show();
                        break;
                    case "Menage FlashCard":
                        break;
                    case "Study":
                        break;
                    case "View Study Sessions":
                        break;
                    case "Exit":
                        return;

                }
            }
        }
    }
}
