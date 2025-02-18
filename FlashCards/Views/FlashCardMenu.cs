using FlashCards.Controllers;
using FlashCards.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public class FlashCardMenu : IMenu
    {
        private static string[] _choices = {"See FlashCards","Delete FlashCard","Edit FlashCard","Exit" };
        private string GetUserChoice()
        {
            var menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
              .Title("[Green]What would you want to do? [/]")
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
                    case "See FlashCards":
                        break;
                    case "Delete FlashCard":
                        break;
                    case "Edit FlashCard":
                        break;
                    case "Exit":
                        return;

                }
            }
        }
    }
}
