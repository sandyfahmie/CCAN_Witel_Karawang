using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatekCCAN.Models
{
    public class WantTSEL
    {
        [Key]
        public int ID3 { get; set; }
        public string ServiceOrder3 { get; set; }
        public string SID3 { get; set; }
        public string TQ3 { get; set; }
        public string AO3 { get; set; }
        public string Name3 { get; set; }
        public DateTime TglOrderItenos3 { get; set; }
        public string Alamat3 { get; set; }
        public string KomenItenos3 { get; set; }
        public string Pic3 { get; set; }
        public string AreaCode3 { get; set; }
        public string Metro3 { get; set; }
        public string Dat3 { get; set; }
        public string Gpon3 { get; set; }
        public string SN3 { get; set; }
        public string Vlan3 { get; set; }
        public DateTime TglPerintahSurvei3 { get; set; }
        public DateTime TglHasilSurvei3 { get; set; }
        public string TaggingPelanggan3 { get; set; }
        public string TeknisiSurvei3 { get; set; }
        public string TaggingODP3 { get; set; }
        public DateTime TglPerintahPT13 { get; set; }
        public DateTime TglSelesaiPTmin13 { get; set; }
        public string TeknisiPTmin13 { get; set; }
        public DateTime TglPerintahJT3 { get; set; }
        public DateTime TglJTSelesai3 { get; set; }
        public string Komen3 { get; set; }
        public DateTime TglClosed3 { get; set; }
        public string Status3 { get; set; }
        public string SiteID { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}