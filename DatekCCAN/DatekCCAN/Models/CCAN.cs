using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatekCCAN.Models
{
    public class CCAN
    {
        [Key]
        public int ID5 { get; set; }
        public string ServiceOrder5 { get; set; }
        public string SID5 { get; set; }
        public string TQ5 { get; set; }
        public string AO5 { get; set; }
        public string Name5 { get; set; }
        public DateTime TglOrderItenos5 { get; set; }
        public string Alamat5 { get; set; }
        public string KomenItenos5 { get; set; }
        public string Pic5 { get; set; }
        public string AreaCode5 { get; set; }
        public string Metro5 { get; set; }
        public string Dat5 { get; set; }
        public string Gpon5 { get; set; }
        public string SN5 { get; set; }
        public string Vlan5 { get; set; }
        public DateTime TglPerintahSurvei5 { get; set; }
        public DateTime TglHasilSurvei5 { get; set; }
        public string TaggingPelanggan5 { get; set; }
        public string TeknisiSurvei5 { get; set; }
        public string TaggingODP5 { get; set; }
        public DateTime TglPerintahPT15 { get; set; }
        public DateTime TglSelesaiPTmin15 { get; set; }
        public string TeknisiPTmin15 { get; set; }
        public DateTime TglPerintahJT5 { get; set; }
        public DateTime TglJTSelesai5 { get; set; }
        public string Komen5 { get; set; }
        public DateTime TglClosed5 { get; set; }
        public string Status5 { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}