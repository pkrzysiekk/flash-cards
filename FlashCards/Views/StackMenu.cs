using FlashCards.Controllers;
using FlashCards.Models;
using FlashCards.Models.Stack;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public class StackMenu : IMenu
    {
        private readonly string[] _stackMenuChoices =
            { "Add Stack", "See Stack" ,"Delete Stack",
            "Add Card to current stack","Edit card from stack","Delete card from stack","Exit" };
        private StackController _stackController = new();


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
                       var stack= UserInput.GetModelToAdd(_=new StackBO());
                       _stackController.Insert(stack);
                        break;
                    case "See Stack":
                       var stackList =  _stackController.GetAll();
                        StackView.ShowStacks(stackList);
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
