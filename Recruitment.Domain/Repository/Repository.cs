using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruitment.Domain.Entity;

namespace Recruitment.Domain.Repository
{
    public class Repository : IRepository
    {
        private readonly RecruitmentContext _context;

        public Repository (RecruitmentContext context)
        {
            _context = context;
        }

        public Task<int> AddCandidate (Candidates candidate)
        {
            try
            {
                //_context.CandidateDetails.Add(candidate);
                //_context.Database.ExecuteSqlCommand("insert into dbo.CandidateDetails() values()")
               _context.Database.ExecuteSqlCommand("spAddCandidate @Name,@PhoneNumber,@CurrentCtc,@NoticePeriod,@Role,@Status,@Date",
                 parameters: new SqlParameter[] {
                new SqlParameter("@Name", candidate.Name),
                new SqlParameter("@PhoneNumber",candidate.PhoneNumber),
                new SqlParameter("@CurrentCtc",candidate.CurrentCtc),
                new SqlParameter("@NoticePeriod",candidate.NoticePeriod),
                new SqlParameter("@Role",candidate.Role),
                new SqlParameter("@Status",candidate.Status),
                new SqlParameter("@Date",candidate.Date)
                 });
               
                var result = _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public async Task<List<Candidates>> GetAllCandidatesAsync ()
        {
            try
            {
                //return await _context.CandidateDetails.ToListAsync();
                return await _context.Candidates.FromSql("spGetAllCandidates").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Candidates> GetCandidateByIdAsync (int Id)
        {
            try
            {
                var candidate = _context.Candidates.Find(Id);
                return candidate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> UpdateCandidate (Candidates candidate)
        {
            try
            {
                //_context.Update(candidate);
                _context.Database.ExecuteSqlCommand("spUpdateCandidate @Id,@Name,@PhoneNumber,@CurrentCtc,@NoticePeriod,@Role,@Status,@Date",
                 parameters: new SqlParameter[] {
                 new SqlParameter("@Id",candidate.Id),
                new SqlParameter("@Name", candidate.Name),
                new SqlParameter("@PhoneNumber",candidate.PhoneNumber),
                new SqlParameter("@CurrentCtc",candidate.CurrentCtc),
                new SqlParameter("@NoticePeriod",candidate.NoticePeriod),
                new SqlParameter("@Role",candidate.Role),
                new SqlParameter("@Status",candidate.Status),
                new SqlParameter("@Date",candidate.Date)
                 });

                var result =_context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public Task<int> DeleteCandidate (int id)
        {
            //var candidate = _context.CandidateDetails.Find(id);
            //_context.CandidateDetails.Remove(candidate);
            _context.Database.ExecuteSqlCommand("spDeleteCandidate @Id",
                parameters: new SqlParameter[] {
                    new SqlParameter("@Id",id)
                });
            var result= _context.SaveChangesAsync();
            return result;
        }

    }
}
