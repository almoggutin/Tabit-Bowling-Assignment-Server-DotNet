using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    interface IScoreModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int Score { get; set; }
    }

    public class ScoreModel: IScoreModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Score is required")]
        public int Score { get; set; }
    }


}
