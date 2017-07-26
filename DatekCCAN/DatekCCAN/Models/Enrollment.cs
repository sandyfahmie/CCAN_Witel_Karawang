namespace DatekCCAN.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Datek Datek { get; set; }
        public Delete Delete { get; set; }
        public CCAN CCAN { get; set; }
        public Modify Modify { get; set; }
        public WAN WAN { get; set; }
        public WantTSEL WantTSEL { get; set; }
    }
}