using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
    public abstract class DbController
    {
        protected string? connectionString;

        protected DbController()
        {
            connectionString= ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        }


    }
}
