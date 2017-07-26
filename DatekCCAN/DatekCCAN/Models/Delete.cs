using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatekCCAN.Models
{
    public class Delete
    {
        [Key]
        public int ID1 { get; set; }
        public string ServiceOrder1 { get; set; }
        public string SID1 { get; set; }
        public string TQ1 { get; set; }
        public string AO1 { get; set; }
        public string Name1 { get; set; }
        public DateTime TglOrderItenos1 { get; set; }
        public string Alamat1 { get; set; }
        public string KomenItenos1 { get; set; }
        public string Pic1 { get; set; }
        public string AreaCode1 { get; set; }
        public string Metro1 { get; set; }
        public string Dat1 { get; set; }
        public string Gpon1 { get; set; }
        public string SN1 { get; set; }
        public string Vlan1 { get; set; }
        public DateTime TglPerintahSurvei1 { get; set; }
        public DateTime TglHasilSurvei1 { get; set; }
        public string TaggingPelanggan1 { get; set; }
        public string TeknisiSurvei1 { get; set; }
        public string TaggingODP1 { get; set; }
        public DateTime TglPerintahPT11 { get; set; }
        public DateTime TglSelesaiPTmin11 { get; set; }
        public string TeknisiPTmin11 { get; set; }
        public DateTime TglPerintahJT1 { get; set; }
        public DateTime TglJTSelesai1 { get; set; }
        public string Komen1 { get; set; }
        public DateTime TglClosed1 { get; set; }
        public string Status1 { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}