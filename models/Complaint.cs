namespace StudentComplaintSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        // Student Information
        public string StudentName { get; set; }
        public string MatricNumber { get; set; }
        public string Level { get; set; }

        // Complaint Information
        public string Title { get; set; }
        public string Description { get; set; }

        // Complaint Status
        public string Status { get; set; } = "Pending";

        // Date Submitted
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}