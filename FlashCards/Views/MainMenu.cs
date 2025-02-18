using FlashCards.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public class MainMenu : IMenu
    {
        private static string[] _choices= { "Menage Stacks", "Menage FlashCards", "Study", "View Study Sessions","Exit" };
        private IMenu _stackMenu= new StackMenu();
        private IMenu _flashCardMenu=new FlashCardMenu();
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
                    case "Menage FlashCards":
                        _flashCardMenu.Show();
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
