using Recruitment.Domain.Entity;
using RecruitmentAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentAPI.Unit.Tests.MockObjects
{
   public static class MockObject
    {
        public static Candidates GetCandidateDetails()
        {
            return new Candidates
            {
                Id = 1,
                Name = "Raj",
                CurrentCtc = "125463",
                NoticePeriod = "2",
                PhoneNumber = "123468",
                Role = "asd",
                Status = "new",
                Date = "12-01-2018"
            };
        }

        public static Candidates GetNewCandidate()
        {
            return new Candidates
            {
                Id = 1,
                Name = "Raj",
                CurrentCtc = "125463",
                NoticePeriod = "2",
                PhoneNumber = "123468",
                Role = "asd",
                Status = "new",
                Date = "12-01-2018"
            };
        }

        public static Candidates GetNewEditCandidate()
        {
            return new Candidates
            {
                Id = 1,
                Name = "Raj",
                CurrentCtc = "125463",
                NoticePeriod = "2",
                PhoneNumber = "123468",
                Role = "asd",
                Status = "new",
                Date = "12-01-2018"
            };
        }

        public static Candidates GetNewCandidateBadRequest()
        {
            return new Candidates
            {

            };
        }
        public async static Task<Candidates> GetCandidateDetailsList()
        {
            Candidates candidateDetails = new Candidates
            {
                Id = 1,
                Name = "Raj",
                CurrentCtc = "125463",
                NoticePeriod = "2",
                PhoneNumber = "123468",
                Role = "asd",
                Status = "new",
                Date = "12-01-2018"
            };
            return candidateDetails;
        }

        public static List<Candidates> GetCandidates()
        {
            return new List<Candidates>
            {
                GetCandidatesList()
            };
        }

        public static Candidates GetCandidatesList ()
        {
            return new Candidates
            {
                Id = 1,
                Name = "Raj",
                CurrentCtc = "125463",
                NoticePeriod = "2",
                PhoneNumber = "123468",
                Role = "asd",
                Status = "new",
                Date = "12-01-2018"
            };
        }
    }
}
