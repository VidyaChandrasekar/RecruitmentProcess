using Recruitment.Domain.Entity;
using RecruitmentAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Mappers
{
    public interface ICandidateMapper
    {
        CandidateDetails MapCreationCandidateDtoToEntity (CandidateDto candidateDto);
    }
}
