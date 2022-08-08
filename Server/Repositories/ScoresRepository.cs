using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Server.Repositories
{
    public interface IScoresRepository 
    {
        Task<List<Scores>> GetScoresAsync(int? limit);
        Task<Scores> AddScoreAsync(ScoreModel score);
    }   

    public class ScoresRepository: IScoresRepository
    {
        private readonly ScoresContext _context;
        private readonly IMapper _mapper;

        public ScoresRepository(ScoresContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<Scores>> GetScoresAsync(int? limit)
        {
            var scoresOrderedQuery = GetScoresOrderedQuery();
            IQueryable<Scores> scoresQuery = scoresOrderedQuery;
            if (limit != null)
            {
                scoresQuery = scoresOrderedQuery.Take((int)limit);
            }

            var scores = await scoresQuery.ToListAsync();

            return scores;
        }


        public async Task<Scores> AddScoreAsync(ScoreModel scoreModel) {
            var score = _mapper.Map<Scores>(scoreModel);

            _context.Scores.Add(score);
            await _context.SaveChangesAsync();

            return score; 
        }

        private IOrderedQueryable<Scores> GetScoresOrderedQuery()
        {
            var scores = _context.Scores.OrderByDescending(s => s.Score);
            return scores;
        }
    }
}
