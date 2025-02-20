using FlashCards.Controllers;
using FlashCards.Models;
using FlashCards.Models.FlashCards;
using FlashCards.Models.Stack;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Views
{
    public class StudyMenu : IMenu
    {
        private string[] _stackMenuChoices = 
            {"Select Stack for study","Exit"   };
        private StackController _stackController=new();
        private FlashCardsController _flashCardsController=new();
        private StudyController _studyController=new();
        private SessionController _sessionController=new();
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
            string choice= GetUserChoice();
            IEnumerable<StackBO> stackList=new LinkedList<StackBO>();
            StackBO stack = new StackBO();
            IEnumerable <FlashCardBO> cards = new List<FlashCardBO>();
            SessionBO session = new SessionBO();
            while (true)
            {
                switch (choice)
                {
                    case "Select Stack for study":
                        stackList=_stackController.GetAllBO();
                        if (stackList.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[White]No stacks avaliable, create one first[/]");
                            continue;
                        }
                        stack = _stackController.GetUserSelection(stackList);
                        cards=_flashCardsController.GetAllCardsFromStack(stack);
                        session = _studyController.StartSession(cards);
                        _sessionController.Insert(stack,session);
                        break;
                    case "Exit":
                        return;
                }
            }

        }
    }
}
