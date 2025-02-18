using FlashCards.Models.Stack;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Controllers
{
    public static class UserInput
    {

        public static T GetModelToAdd<T>(T model)
        {
            switch (model)
            {
                case StackBO:
                    string nameToAdd = AnsiConsole.Prompt(
                   new TextPrompt<string>("[Green]Insert the name of the stack to add: [/]")
                   );
                    return (T)(Object)new StackBO() { Name = nameToAdd };
                
                    default:
                    return model;



            }


        }
    }
}
