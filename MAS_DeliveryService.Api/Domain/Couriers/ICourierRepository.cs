using MAS_DeliveryService.Api.Domain.Enums;

namespace MAS_DeliveryService.Api.Domain.Couriers;

public interface ICourierRepository
{
    public Task AddCourier(string fname, string lname, string num, DateTime dateOfBirth, decimal salary, ContractType contractType);
    public Task AddCourier(Guid personId, DateTime dateOfBirth, decimal salary, ContractType contractType);
    public Task<Courier?> GetCourier(Guid courierId);
    public Task<List<Courier>> GetCouriers();
    public Task UpdateCourier(Guid courierId, string fname, string lname, string num);
}