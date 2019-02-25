using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Dtos
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentCtc { get; set; }
        public string NoticePeriod { get; set; }
        public string Role { get; set; }
    }
}
