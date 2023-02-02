using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Enteties
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Time { get; set; }

       // public Tournament tournament { get; set; } = new Tournament(); //Nav. Prop.
        public int TournamentId { get; set; } //FK
    }
}
