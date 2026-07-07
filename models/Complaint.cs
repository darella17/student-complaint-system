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

        // NEW: Complaint Category
        public string Category { get; set; }


        // Double Confirmation
        public bool AdminResolved { get; set; } = false;

        public bool StudentConfirmed { get; set; } = false;

        // Complaint Status
        public string Status
        {
            get
            {
                if (AdminResolved && StudentConfirmed)
                    return "Fully Resolved";

                if (AdminResolved)
                    return "Pending Student Confirmation";

                return "Pending";
            }
        }

        // Date Submitted
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}