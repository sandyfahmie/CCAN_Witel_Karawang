using DatekCCAN.Models;
using System;
using System.Linq;

namespace DatekCCAN.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WitelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any data
            if (context.Dateks.Any())
            {
                return;   // DB has been seeded
            }

            var dateks = new Datek[]
            {
            new Datek{ServiceOrder="30010753103172457864", SID="300107502-0030662655", TQ="80014077710000000010", AO="80014257240000000010", Name="YAY BINA PRESTASI INDONESIA GEMILANGYAY BINA PRESTASI INDONESIA GEMILANG  KAMPUS AL AZHAR GALUH MAS KARAWANG",TglOrderItenos=DateTime.Parse("2017-03-31 08:37:42"), Alamat="JL. ARTERI GALUH MAS TELUKJAMBE,00,KARAWANG,POST CODE : 41361,351", KomenItenos="PAKET 1 MB ASTINET", Pic="PIC JUNJUN JUNIAWAN 085810185622 AM SARI TEJOWATI 08115227227", AreaCode="KWKTLJ", Metro="ME-D2-KRW#3/2/2", Dat="GPON01-D3-KRW-3#1/9/6:20", Gpon="V-3#1/9/6:20", SN="ZTEGC1C8F40B", Vlan="3435", TaggingPelanggan="255.248", Status="closed"}
            };
            foreach (Datek s in dateks)
            {
                context.Dateks.Add(s);
            }
            context.SaveChanges();

            var coures = new Course[]
            {
            new Course{CourseID=1,Title="CCAN"}
            };
            foreach (Course c in coures)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A}
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

            if (context.Deletes.Any())
            {
                return;   // DB has been seeded
            }

            var delete = new Delete[]
            {
                new Delete{AO1="80013909110000000010", Name1="TELKOM PDC KARAWANG", TglOrderItenos1=DateTime.Parse("2017-9-3  4:04:45"), Alamat1="JL. SUROTO KUNTO RUKO KAARWANG ASRI KEL.ADIARSA TIMUR KRW,B22,KARAWANG,POST CODE : 41361,351", KomenItenos1="DBSR3 ASTN 2 MB TELKOM PDC KRW", Pic1="CABUT KARENA PELANGGAN SDH GK BUTUH LAGI PERAWAL FEB 2017"}
            };
            foreach (Delete w in delete)
            {
                context.Deletes.Add(w);
            }
            context.SaveChanges();
        }
    }
}