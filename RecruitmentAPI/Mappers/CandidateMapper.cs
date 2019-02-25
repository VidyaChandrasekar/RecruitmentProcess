using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Recruitment.Domain.Entity;
using RecruitmentAPI.Dtos;

namespace RecruitmentAPI.Mappers
{
    public class CandidateMapper : ICandidateMapper
    {
        public CandidateDetails MapCreationCandidateDtoToEntity (CandidateDto candidateDto)
        {
            CandidateDetails candidate = new CandidateDetails
            {
                Id = candidateDto.Id,
                Name = candidateDto.Name,
                PhoneNumber = candidateDto.PhoneNumber,
                CurrentCtc = candidateDto.CurrentCtc,
                NoticePeriod = candidateDto.NoticePeriod,
                Role = candidateDto.Role
            };

            return Mapper.Map<CandidateDetails>(candidate);
        }
    }
}
