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
            ProductId = form.ProductId,
        };

        // Convert ProjectEntity to ProjectModel
        public static ProjectModel? Create(ProjectEntity entity) => entity == null ? null : new()
        {
            ProjectId = entity.ProjectId, // Assuming 'Id' in ProjectEntity corresponds to ProjectId
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            StatusId = entity.StatusId,
            StatusName = entity.Status?.StatusName ?? "Unknown",
            UserId = entity.UserId,
            UserName = entity.User != null ? $"{entity.User.FirstName} {entity.User.LastName}" : "Unknown",
            ProductId = entity.ProductId,
            ProductName = entity.Product?.ProductName ?? "Unknown",
        };

        // Convert ProjectModel back to ProjectEntity
        public static ProjectEntity? Create(ProjectModel project) => project == null ? null : new()
        {
            ProjectId = project.ProjectId, // Ensuring consistency with entity ID
            Title = project.Title,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            StatusId = project.StatusId,
            UserId = project.UserId,
            ProductId = project.ProductId,

        };
    }
}
