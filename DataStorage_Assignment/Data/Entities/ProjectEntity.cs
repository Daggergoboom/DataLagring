using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int ProjectId { get; set; } // Replacing Id with ProjectId

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public StatusTypeEntity Status { get; set; } = null!;

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        // Removed ProductId and ProductEntity

        // ✅ Adding CustomerId and Customer for compatibility with other parts of the app
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
