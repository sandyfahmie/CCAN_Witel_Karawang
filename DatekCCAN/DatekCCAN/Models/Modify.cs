using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatekCCAN.Models
{
    public class Modify
    {
        [Key]
        public int ID2 { get; set; }
        public string ServiceOrder2 { get; set; }
        public string SID2 { get; set; }
        public string TQ2 { get; set; }
        public string AO2 { get; set; }
        public string Name2 { get; set; }
        public DateTime TglOrderItenos2 { get; set; }
        public string Alamat2 { get; set; }
        public string KomenItenos2 { get; set; }
        public string Pic2 { get; set; }
        public string AreaCode2 { get; set; }
        public string Metro2 { get; set; }
        public string Dat2 { get; set; }
        public string Gpon2 { get; set; }
        public string SN2 { get; set; }
        public string Vlan2 { get; set; }
        public DateTime TglPerintahSurvei2 { get; set; }
        public DateTime TglHasilSurvei2 { get; set; }
        public string TaggingPelanggan2 { get; set; }
        public string TeknisiSurvei2 { get; set; }
        public string TaggingODP2 { get; set; }
        public DateTime TglPerintahPT12 { get; set; }
        public DateTime TglSelesaiPTmin12 { get; set; }
        public string TeknisiPTmin12 { get; set; }
        public DateTime TglPerintahJT2 { get; set; }
        public DateTime TglJTSelesai2 { get; set; }
        public string Komen2 { get; set; }
        public DateTime TglClosed2 { get; set; }
        public string Status2 { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}