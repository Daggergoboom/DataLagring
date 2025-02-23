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
        private readonly UserRepository _userRepository;

        public ProjectService(ProjectRepository projectRepository, CustomerRepository customerRepository, UserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        // ✅ Fetch all customers (without duplicates)
        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAsync();
            return customers.Select(c => new CustomerModel
            {
                Id = c.Id,
                CustomerName = c.CustomerName
            });
        }

        // ✅ Create a new customer and return the created customer
        public async Task<CustomerModel> CreateCustomerAsync(string customerName)
        {
            var newCustomer = new CustomerEntity
            {
                CustomerName = customerName
            };

            await _customerRepository.AddAsync(newCustomer);

            return new CustomerModel
            {
                Id = newCustomer.Id,
                CustomerName = newCustomer.CustomerName
            };
        }

        // ✅ Fetch all users for selection
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAsync();
            return users.Select(u => new UserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            });
        }

        // ✅ Create a new project with customer and user validation
        public async Task CreateProjectAsync(ProjectRegistration form)
        {
            var customers = await _customerRepository.GetAsync();
            var existingCustomer = customers.FirstOrDefault(c => c.Id == form.CustomerId);

            if (existingCustomer == null)
            {
                throw new Exception("Customer not found.");
            }

            var users = await _userRepository.GetAsync();
            var existingUser = users.FirstOrDefault(u => u.Id == form.UserId);

            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

            var projectEntity = ProjectFactory.Create(form);
            if (projectEntity != null)
            {
                projectEntity.CustomerId = existingCustomer.Id;
                projectEntity.UserId = existingUser.Id;
                await _projectRepository.AddAsync(projectEntity);
            }
        }

        // ✅ Retrieve all projects
        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            var projectEntities = await _projectRepository.GetAsync();
            return projectEntities.Select(ProjectFactory.Create)!;
        }

        // ✅ Retrieve a project by ID
        public async Task<ProjectModel?> GetProjectByIdAsync(int projectId)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == projectId);
            return ProjectFactory.Create(projectEntity!);
        }

        // ✅ Retrieve a project by name
        public async Task<ProjectModel?> GetProjectByNameAsync(string projectName)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Title == projectName);
            return ProjectFactory.Create(projectEntity!);
        }

        // ✅ Update an existing project
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

        // ✅ Delete a project by ID
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == projectId);
            if (projectEntity == null) return false;

            await _projectRepository.RemoveAsync(projectEntity);
            return true;
        }
    }
}
