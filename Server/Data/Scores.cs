using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    interface IScores
    {
        int Id { get; set; }
        string Name { get; set; }
        int Score { get; set; }
    }

    public class Scores: IScores
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
