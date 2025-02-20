using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
   public class SessionBO
    {
        int? Id { get; set; }
        public int Score { get; set; }
        public int  MaxScore { get; set; }
        public DateTime Date { get; set; }
        public int StackId { get; set; }
    }
}
