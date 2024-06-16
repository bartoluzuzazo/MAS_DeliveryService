using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Couriers;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.People;

namespace MAS_DeliveryService.Api.Repositories;

public class CourierRepository : ICourierRepository
{
    private readonly Context _context;

    public CourierRepository(Context context)
    {
        _context = context;
    }

    public async Task AddCourier(string fname, string lname, string num, DateTime dateOfBirth, decimal salary, ContractType contractType)
    {
        var person = new Person(fname, lname, num);
        await _context.Persons.AddAsync(person);
        var courier = new Courier(person.Id, dateOfBirth, salary, contractType);
        await _context.Couriers.AddAsync(courier);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddCourier(Guid personId, DateTime dateOfBirth, decimal salary, ContractType contractType)
    {
        var courier = new Courier(personId, dateOfBirth, salary, contractType);
        await _context.Couriers.AddAsync(courier);
        await _context.SaveChangesAsync();
    }
}