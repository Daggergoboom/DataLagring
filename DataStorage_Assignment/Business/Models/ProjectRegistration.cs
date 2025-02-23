namespace Business.Models
{
    public class ProjectRegistration
    {
        public int ProjectId { get; set; } = GenerateProjectId(); // Auto-generated Project ID

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key Inputs
        public int StatusId { get; set; }  // FK for StatusTypes (Not Started, Ongoing, Finished)
        public int UserId { get; set; }    // FK for Project Manager (User ID)
        public int CustomerId { get; set; } // FK for CustomerEntity
        public string CustomerName { get; set; } = string.Empty; // ✅ Add this line

        // Method to auto-generate Project ID
        private static int GenerateProjectId()
        {
            // Generate a random ID between 1000 and 9999
            var random = new Random();
            return random.Next(1000, 9999);
        }
    }
}
