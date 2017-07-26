using System;
using System.Collections.Generic;

namespace DatekCCAN.Models
{
    public class Datek
    {
        public int ID { get; set; }
        public string ServiceOrder { get; set; }
        public string SID { get; set; }
        public string TQ { get; set; }
        public string AO { get; set; }
        public string Name { get; set; }
        public DateTime TglOrderItenos { get; set; }
        public string Alamat { get; set; }
        public string KomenItenos { get; set; }
        public string Pic { get; set; }
        public string AreaCode { get; set; }
        public string Metro { get; set; }
        public string Dat { get; set; }
        public string Gpon { get; set; }
        public string SN { get; set; }
        public string Vlan { get; set; }
        public DateTime TglPerintahSurvei { get; set; }
        public DateTime TglHasilSurvei { get; set; }
        public string TaggingPelanggan { get; set; }
        public string TeknisiSurvei { get; set; }
        public string TaggingODP { get; set; }
        public DateTime TglPerintahPT1 { get; set; }
        public DateTime TglSelesaiPTmin1 { get; set; }
        public string TeknisiPTmin1 { get; set; }
        public DateTime TglPerintahJT { get; set; }
        public DateTime TglJTSelesai { get; set; }
        public string Komen { get; set; }
        public DateTime TglClosed { get; set; }
        public string Status { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}