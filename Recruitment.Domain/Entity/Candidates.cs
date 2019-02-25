using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Domain.Entity
{
   public class Candidates
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentCtc { get; set; }
        public string NoticePeriod { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
