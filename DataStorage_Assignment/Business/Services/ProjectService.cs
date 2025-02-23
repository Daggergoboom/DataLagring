using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;
        private readonly CustomerRepository _customerRepository;

        public ProjectService(ProjectRepository projectRepository, CustomerRepository customerRepository)
        {
            _projectRepository = projectRepository;
            _customerRepository = customerRepository;
        }

        // Create a new project with automatic customer assignment
        public async Task CreateProjectAsync(ProjectRegistration form)
        {
            var customers = await _customerRepository.GetAsync();
            var existingCustomer = customers.FirstOrDefault();

            // If no customers exist, create a default one
            if (existingCustomer == null)
            {
                var defaultCustomer = new CustomerEntity
                {
                    CustomerName = "Default Customer"
                };
                await _customerRepository.AddAsync(defaultCustomer);
                existingCustomer = defaultCustomer;
            }

            // Create the project entity from the form and assign customer ID
            var projectEntity = ProjectFactory.Create(form);
            if (projectEntity != null)
            {
                projectEntity.CustomerId = existingCustomer.Id;
                await _projectRepository.AddAsync(projectEntity);
            }
        }

        // Retrieve all projects
        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            var projectEntities = await _projectRepository.GetAsync();
            return projectEntities.Select(ProjectFactory.Create)!;
        }

        // Retrieve a project by ID
        public async Task<ProjectModel?> GetProjectByIdAsync(int projectId)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == projectId);
            return ProjectFactory.Create(projectEntity!);
        }

        // Retrieve a project by its name
        public async Task<ProjectModel?> GetProjectByNameAsync(string projectName)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Title == projectName);
            return ProjectFactory.Create(projectEntity!);
        }

        // Update an existing project
        public async Task<bool> UpdateProjectAsync(ProjectModel project)
        {
            var existingProject = await _projectRepository.GetAsync(x => x.ProjectId == project.ProjectId);
            if (existingProject == null) return false;

            var updatedProject = ProjectFactory.Create(project);
            if (updatedProject != null)
            {
                await _projectRepository.UpdateAsync(updatedProject);
                return true;
            }

            return false;
        }

        // Delete a project by its ID
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == projectId);
            if (projectEntity == null) return false;

            await _projectRepository.RemoveAsync(projectEntity);
            return true;
        }
    }
}