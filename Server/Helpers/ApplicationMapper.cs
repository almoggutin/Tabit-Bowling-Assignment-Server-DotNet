using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Data;
using Server.Models;

namespace Server.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Scores, ScoreModel>().ReverseMap();
        }
    }
}
