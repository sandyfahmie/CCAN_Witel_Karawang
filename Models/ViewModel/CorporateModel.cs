using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    // agar bisa Display & Required

namespace CCAN_Witel_Karawang.Models.ViewModel
{
    public class CorporateModel                 // middleware antara model & view signup: validasi dll
    {
        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "NIK")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Nama")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Jenis Kelamin")]
        public string Gender { get; set; }
        [Display(Name = "Divisi")]
        public string Division { get; set; }
        [Display(Name = "No. Telp / HP")]
        public string Phone { get; set; }
    }
}