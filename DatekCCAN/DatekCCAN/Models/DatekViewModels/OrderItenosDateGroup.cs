using System;
using System.ComponentModel.DataAnnotations;

namespace DatekCCAN.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? TglClosed { get; set; }

        public int DatekCount { get; set; }
    }
}