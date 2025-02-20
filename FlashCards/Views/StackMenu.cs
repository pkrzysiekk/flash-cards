using FlashCards.Controllers;
using FlashCards.Models;
using FlashCards.Models.FlashCards;
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
            { "Add Stack", "See Stack" ,"Delete Stack","Update Stack",
            "Add Card to stack","Edit card from stack","Delete card from stack","Exit" };
        private StackController _stackController = new();
        private FlashCardsController _cardController = new();


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
            StackBO stackBO = new StackBO();
            StackDTO stackDTO = new StackDTO();
            IEnumerable<StackBO> stackListBO=new List<StackBO>();
            IEnumerable<StackDTO> stackListDTO = new List<StackDTO>();
            while (true)
            {
                string choice = GetUserChoice();
                AnsiConsole.Clear();
                switch (choice)
                {
                    case "Add Stack":
                        stackBO= UserInput.GetModelToAdd(_=new StackBO());
                       _stackController.Insert(stackBO);
                        break;
                    case "See Stack":
                        stackListDTO =  _stackController.GetAllDTO();
                        stackListBO = _stackController.GetAllBO();
                        if (stackListDTO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[White] No stacks, add one first[/]");
                            continue;
                        }
                        StackView.ShowStacks(stackListDTO);
                        break;
                    case "Delete Stack":
                        stackListBO = _stackController.GetAllBO();
                        if (stackListBO.Count()==0)
                        {
                            AnsiConsole.MarkupLine("[White] No stacks, add one first[/]");
                            continue;
                        }
                        stackBO = _stackController.GetUserSelection(stackListBO);
                        _stackController.Remove(stackBO);
                        break;
                    case "Update Stack":
                        stackListBO=_stackController.GetAllBO();
                        if (stackListBO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[White] No stacks, add one first[/]");
                            continue;
                        }
                        stackBO = _stackController.GetUserSelection(stackListBO);
                        var newStack=UserInput.GetModelToAdd(_=new StackBO());
                        _stackController.Update(stackBO,newStack);
                        break;
                    case "Add Card to stack":
                        stackListBO = _stackController.GetAllBO();
                        if (stackListBO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[White] No stacks, add one first[/]");
                            continue;
                        }
                        stackBO = _stackController.GetUserSelection(stackListBO);                       
                        AnsiConsole.MarkupLine($"[Purple]Current Stack {stackBO.Name}[/]");
                        var cardToAdd = UserInput.GetModelToAdd(_ = new FlashCardBO());
                        _cardController.Insert(stackBO, cardToAdd);
                        break;
                    case "Exit":
                        return;
                    case "Edit card from stack":
                        stackListBO = _stackController.GetAllBO();
                        if (stackListBO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[White] No stacks, add one first[/]");
                            continue;
                        }
                        stackBO = _stackController.GetUserSelection(stackListBO);
                        AnsiConsole.MarkupLine($"[Purple]Current Stack {stackBO.Name}[/]");
                        var currStackCards = _cardController.GetAllCardsFromStack(stackBO);
                        var cardToEdit = _cardController.GetUserCardSelection(currStackCards);
                        AnsiConsole.MarkupLine($"[Purple]Currently editing: {cardToEdit.Name1} || {cardToEdit.Name2}[/]");
                        var newCard = UserInput.GetModelToAdd(_ = new FlashCardBO());
                        _cardController.Update(cardToEdit,newCard);
                        return;
                    case "Delete card from stack":
                        stackListBO = _stackController.GetAllBO();
                        if (stackListBO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[White] No stacks, add one first[/]");
                            continue;
                        }
                        var stackToDeleteFrom = _stackController.GetUserSelection(stackListBO);
                        AnsiConsole.MarkupLine($"[Purple]Current Stack {stackToDeleteFrom.Name}[/]");
                        var currStackCardsToDelete = _cardController.GetAllCardsFromStack(stackToDeleteFrom);
                        var cardToDelete = _cardController.GetUserCardSelection(currStackCardsToDelete);
                        _cardController.Delete(cardToDelete);
                        break;
                }
            }

        }
    }
}
