using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public class CandidateDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentCtc { get; set; }
        public string NoticePeriod { get; set; }
        public string Role { get; set; }
        public string Date { get; set; }
    }
}
