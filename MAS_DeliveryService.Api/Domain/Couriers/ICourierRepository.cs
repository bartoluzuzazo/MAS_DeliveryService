using MAS_DeliveryService.Api.Domain.Enums;

namespace MAS_DeliveryService.Api.Domain.Couriers;

public interface ICourierRepository
{
    public Task AddCourier(string fname, string lname, string num, DateTime dateOfBirth, decimal salary, ContractType contractType);
    public Task AddCourier(Guid personId, DateTime dateOfBirth, decimal salary, ContractType contractType);

}