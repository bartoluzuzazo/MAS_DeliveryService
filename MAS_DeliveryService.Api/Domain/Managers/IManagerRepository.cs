using MAS_DeliveryService.Api.Domain.Enums;

namespace MAS_DeliveryService.Api.Domain.Managers;

public interface IManagerRepository
{
    public Task AddManager(string fname, string lname, string num, DateTime dateOfBirth, decimal salary,
        ContractType contractType, string education);
    
    public Task AddManager(Guid personId, DateTime dateOfBirth, decimal salary,
        ContractType contractType, string education);
    public Task<Manager?> GetManager(Guid managerId);
    public Task<List<Manager>> GetManagers();
    public Task UpdateManager(Guid managerId, string fname, string lname, string num, string education);
}