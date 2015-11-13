using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentApi.ViewModels
{
    public class MatchViewModel
    {
        public int Round { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Status { get; set; }
        public string GameShortcode { get; set; }
    }
}
