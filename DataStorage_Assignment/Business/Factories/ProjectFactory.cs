using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        // Convert ProjectRegistration to ProjectEntity
        public static ProjectEntity? Create(ProjectRegistration form) => form == null ? null : new()
        {
            Title = form.Title,
            Description = form.Description,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            StatusId = form.StatusId,
            UserId = form.UserId,
            CustomerId = form.CustomerId
        };

        // Convert ProjectEntity to ProjectModel
        public static ProjectModel? Create(ProjectEntity entity) => entity == null ? null : new()
        {
            ProjectId = entity.ProjectId, // Assuming 'Id' in ProjectEntity corresponds to ProjectId
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            StatusId = entity.StatusId ?? 0, // Handle nullable int
            StatusName = entity.Status?.StatusName ?? "Unknown",
            UserId = entity.UserId,
            UserName = entity.User != null ? $"{entity.User.FirstName} {entity.User.LastName}" : "Unknown",
            CustomerId = entity.CustomerId,
            CustomerName = entity.Customer != null ? entity.Customer.CustomerName : "Unknown",
            ServicePricePerHour = 0, // Assuming default value since pricing is not provided in entity
            TotalPrice = 0 // Placeholder for total price calculation if needed later
        };

        // Convert ProjectModel back to ProjectEntity
        public static ProjectEntity? Create(ProjectModel project) => project == null ? null : new()
        {
            ProjectId = project.ProjectId,
            Title = project.Title,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            StatusId = project.StatusId,
            UserId = project.UserId,
            CustomerId = project.CustomerId
        };
    }
}
