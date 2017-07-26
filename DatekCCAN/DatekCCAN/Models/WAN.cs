using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatekCCAN.Models
{
    public class WAN
    {
        [Key]
        public int ID4 { get; set; }
        public string ServiceOrder4 { get; set; }
        public string SID4 { get; set; }
        public string TQ4 { get; set; }
        public string AO4 { get; set; }
        public string Name4 { get; set; }
        public DateTime TglOrderItenos4 { get; set; }
        public string Alamat4 { get; set; }
        public string KomenItenos4 { get; set; }
        public string Pic4 { get; set; }
        public string AreaCode4 { get; set; }
        public string Metro4 { get; set; }
        public string Dat4 { get; set; }
        public string Gpon4 { get; set; }
        public string SN4 { get; set; }
        public string Vlan4 { get; set; }
        public DateTime TglPerintahSurvei4 { get; set; }
        public DateTime TglHasilSurvei4 { get; set; }
        public string TaggingPelanggan4 { get; set; }
        public string TeknisiSurvei4 { get; set; }
        public string TaggingODP4 { get; set; }
        public DateTime TglPerintahPT14 { get; set; }
        public DateTime TglSelesaiPTmin14 { get; set; }
        public string TeknisiPTmin14 { get; set; }
        public DateTime TglPerintahJT4 { get; set; }
        public DateTime TglJTSelesai4 { get; set; }
        public string Komen4 { get; set; }
        public DateTime TglClosed4 { get; set; }
        public string Status4 { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}