namespace Business.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key Data
        public int StatusId { get; set; }
        public string StatusName { get; set; } = "Unknown"; // ✅ Simplified status handling

        public int UserId { get; set; }
        public string UserName { get; set; } = "Unknown";

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "Unknown"; // ✅ Added for displaying the customer name

        // Service and Pricing
        public decimal ServicePricePerHour { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
