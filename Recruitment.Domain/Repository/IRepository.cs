using Recruitment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Domain.Repository
{
   public interface IRepository
    {
        Task<List<Candidates>> GetAllCandidatesAsync ();
        Task<int> AddCandidate (Candidates candidate);
        Task<int> UpdateCandidate (Candidates candidate);
        Task<Candidates>  GetCandidateByIdAsync (int Id);
        Task<int> DeleteCandidate (int id);
    }
}
