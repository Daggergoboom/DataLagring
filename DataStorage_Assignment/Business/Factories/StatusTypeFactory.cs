using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class StatusTypeFactory
    {
        public static StatusTypeModel? Create(StatusTypeEntity entity) => entity == null ? null : new()
        {
            Id = entity.Id,
            StatusName = entity.StatusName
        };

        public static StatusTypeEntity? Create(StatusTypeModel model) => model == null ? null : new()
        {
            Id = model.Id,
            StatusName = model.StatusName
        };
    }
}