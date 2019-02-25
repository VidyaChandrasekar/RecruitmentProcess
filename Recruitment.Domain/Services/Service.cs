using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Recruitment.Domain.Entity;
using Recruitment.Domain.Repository;

namespace Recruitment.Domain.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service (IRepository repository)
        {
            _repository = repository;
        }

        public Task<int> AddCandidate (Candidates candidate)
        {
            return _repository.AddCandidate(candidate);
        }

        public Task<int> DeleteCandidate (int id)
        {
            return _repository.DeleteCandidate(id);
        }

        public Task<List<Candidates>> GetAllCandidatesAsync ()
        {
            return _repository.GetAllCandidatesAsync();
        }

        public Task<Candidates> GetCandidateById (int Id)
        {
            return _repository.GetCandidateByIdAsync(Id);
        }

        public Task<int> UpdateCandidate (Candidates candidate)
        {
            return _repository.UpdateCandidate(candidate);
        }
    }
}
