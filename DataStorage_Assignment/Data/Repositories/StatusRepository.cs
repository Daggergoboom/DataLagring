using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusTypeEntity>(context)
{
    private readonly DataContext _contexts = context;
}
