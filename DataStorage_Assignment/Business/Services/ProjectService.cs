using Business.Factories;
using Business.Models; // Ensure this using directive is present for ProjectModel
using Data.Repositories;

namespace Business.Services
{
    public class ProjectService(ProjectRepository projectRepository)
    {
        private readonly ProjectRepository _projectRepository = projectRepository;

        // Create a new project with an auto-generated project number
        public async Task CreateProjectAsync(ProjectRegistration form)
        {
            var projectEntity = ProjectFactory.Create(form);
            if (projectEntity != null)
            {
                await _projectRepository.AddAsync(projectEntity);
            }
        }

        // Generate a unique project number (e.g., "P-1001")
        private string GenerateProjectNumber()
        {
            var random = new Random();
            return $"P-{random.Next(1000, 9999)}"; // Generates a random project number between P-1000 and P-9999
        }

        // Get all projects
        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            var projectEntities = await _projectRepository.GetAsync();
            return projectEntities.Select(ProjectFactory.Create)!;
        }

        // Get project by ProjectId
        public async Task<ProjectModel?> GetProjectByIdAsync(int projectId)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == projectId);
            return ProjectFactory.Create(projectEntity!);
        }

        // Get project by name
        public async Task<ProjectModel?> GetProjectByNameAsync(string projectName)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Title == projectName);
            return ProjectFactory.Create(projectEntity!);
        }

        // Update existing project while preserving the original project number
        public async Task<bool> UpdateProjectAsync(ProjectModel project)
        {
            var existingProject = await _projectRepository.GetAsync(x => x.ProjectId == project.ProjectId);
            if (existingProject == null) return false;

            // Preserve the original project number
            var projectEntity = ProjectFactory.Create(project);
            if (projectEntity != null)
            {
                await _projectRepository.UpdateAsync(projectEntity);
                return true;
            }
            return false;
        }

        // Delete project by ProjectId
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == projectId);
            if (projectEntity == null) return false;

            await _projectRepository.RemoveAsync(projectEntity);
            return true;
        }
    }
}