using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int ProjectId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        // EF will create this column as a date type in SQL
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Foreign key to StatusTypes.Id
        public int? StatusId { get; set; }


        // Navigation property for the related StatusTypeEntity
        public StatusTypeEntity? Status { get; set; }


        // Foreign key to Users.Id
        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        // Foreign key to Customers.Id
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
