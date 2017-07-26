using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DatekCCAN.Data;

namespace DatekCCAN.Migrations
{
    [DbContext(typeof(WitelContext))]
    [Migration("20170718040259_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatekCCAN.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits");

                    b.Property<string>("Title");

                    b.HasKey("CourseID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DatekCCAN.Models.Datek", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AO");

                    b.Property<string>("Alamat");

                    b.Property<string>("AreaCode");

                    b.Property<string>("Dat");

                    b.Property<string>("Gpon");

                    b.Property<string>("Komen");

                    b.Property<string>("KomenItenos");

                    b.Property<string>("Metro");

                    b.Property<string>("Name");

                    b.Property<string>("Pic");

                    b.Property<string>("SID");

                    b.Property<string>("SN");

                    b.Property<string>("ServiceOrder");

                    b.Property<string>("Status");

                    b.Property<string>("TQ");

                    b.Property<string>("TaggingODP");

                    b.Property<string>("TaggingPelanggan");

                    b.Property<string>("TeknisiPTmin1");

                    b.Property<string>("TeknisiSurvei");

                    b.Property<DateTime>("TglClosed");

                    b.Property<DateTime>("TglHasilSurvei");

                    b.Property<DateTime>("TglJTSelesai");

                    b.Property<DateTime>("TglOrderItenos");

                    b.Property<DateTime>("TglPerintahJT");

                    b.Property<DateTime>("TglPerintahPT1");

                    b.Property<DateTime>("TglPerintahSurvei");

                    b.Property<DateTime>("TglSelesaiPTmin1");

                    b.Property<string>("Vlan");

                    b.HasKey("ID");

                    b.ToTable("Datek");
                });

            modelBuilder.Entity("DatekCCAN.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int?>("DatekID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("DatekID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("DatekCCAN.Models.Enrollment", b =>
                {
                    b.HasOne("DatekCCAN.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatekCCAN.Models.Datek", "Datek")
                        .WithMany("Enrollments")
                        .HasForeignKey("DatekID");
                });
        }
    }
}
