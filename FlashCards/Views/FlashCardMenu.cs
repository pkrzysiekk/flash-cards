using FlashCards.Controllers;
using FlashCards.Models;
using FlashCards.Models.FlashCards;
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
        private FlashCardsController _flashCardController= new();
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
                IEnumerable<FlashCardBO> cardsList= new List<FlashCardBO>();
                IEnumerable<FlashCardDTO> cardsListDTO = new List<FlashCardDTO>();
                AnsiConsole.Clear();
                switch (choice)
                {
                    case "See FlashCards":
                         cardsListDTO = _flashCardController.GetAllCardsDTO();
                        if (cardsListDTO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine($"[White]No cards,create one first[/]");
                            continue;
                        }
                        CardView.ShowCollection(cardsListDTO);
                        break;
                    case "Delete FlashCard":
                        cardsList = _flashCardController.GetAllCardsBO();
                        if (cardsList.Count() == 0)
                        {
                            AnsiConsole.MarkupLine($"[White]No cards,create one first[/]");
                            continue;
                        }
                        var cardToDelete = _flashCardController.GetUserCardSelection(cardsList);
                        _flashCardController.Delete(cardToDelete);
                        break;
                    case "Edit FlashCard":
                        cardsList = _flashCardController.GetAllCardsBO();
                        if (cardsListDTO.Count() == 0)
                        {
                            AnsiConsole.MarkupLine($"[White]No cards,create one first[/]");
                            continue;
                        }
                        var cardToEdit = _flashCardController.GetUserCardSelection(cardsList);
                        AnsiConsole.MarkupLine($"[Blue] Currently edditing: {cardToEdit.Name1} || {cardToEdit.Name2} [/]");
                        var newCard = UserInput.GetModelToAdd(_ = new FlashCardBO());
                        _flashCardController.Update(cardToEdit, newCard);
                        break;
                    case "Exit":
                        return;

                }
            }
        }
    }
}
