using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models.FlashCards
{
    public class FlashCardBO
    {
        public int Id { get; set; }
        public int StackId { get; set; }
        public string? Name1 { get; set; }
        public string? Name2 { get; set; }

    }
}
