using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services
{
    public class StatusTypeService(StatusRepository statusTypeRepository)
    {
        private readonly StatusRepository _statusTypeRepository = statusTypeRepository;

        // Create a new status type
        public async Task CreateStatusTypeAsync(StatusTypeModel model)
        {
            var entity = StatusTypeFactory.Create(model);
            if (entity != null)
            {
                await _statusTypeRepository.AddAsync(entity);
            }
        }

        // Get all status types
        public async Task<IEnumerable<StatusTypeModel>> GetStatusTypesAsync()
        {
            var statusTypeEntities = await _statusTypeRepository.GetAsync();
            return statusTypeEntities.Select(StatusTypeFactory.Create)!;
        }

        // Get a status type by ID
        public async Task<StatusTypeModel?> GetStatusTypeByIdAsync(int id)
        {
            var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
            return StatusTypeFactory.Create(statusTypeEntity!);
        }

        // Update an existing status type
        public async Task<bool> UpdateStatusTypeAsync(StatusTypeModel model)
        {
            var existingStatusType = await _statusTypeRepository.GetAsync(x => x.Id == model.Id);
            if (existingStatusType == null) return false;

            var entity = StatusTypeFactory.Create(model);
            if (entity != null)
            {
                await _statusTypeRepository.UpdateAsync(entity);
                return true;
            }
            return false;
        }

        // Delete a status type by ID
        public async Task<bool> DeleteStatusTypeAsync(int id)
        {
            var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
            if (statusTypeEntity == null) return false;

            await _statusTypeRepository.RemoveAsync(statusTypeEntity);
            return true;
        }
    }
}