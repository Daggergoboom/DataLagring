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

        // Foreign Key Inputs
        public int StatusId { get; set; }
        public string Status { get; set; } = "Unknown";
        public string StatusName { get; set; } = "Unknown"; // ✅ Add this property

        public int UserId { get; set; }
        public string UserName { get; set; } = "Unknown";

        public int ProductId { get; set; }
        public string ProductName { get; set; } = "Unknown";

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "Unknown";

        // Service and Pricing
        public decimal ServicePricePerHour { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
