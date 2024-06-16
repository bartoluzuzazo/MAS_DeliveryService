using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Couriers;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.People;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<Courier?> GetCourier(Guid courierId)
    {
        return await _context.Couriers.Include(c => c.Person).FirstOrDefaultAsync(c => c.Id == courierId);
    }
    
    public async Task<List<Courier>> GetCouriers()
    {
        return await _context.Couriers.Include(m => m.Person).ToListAsync();
    }

    public async Task UpdateCourier(Guid courierId, string fname, string lname, string num)
    {
        var courier = await _context.Couriers.Include(c => c.Person).FirstOrDefaultAsync(c => c.Id == courierId);
        if (courier is null) throw new Exception($"Courier with id {courierId} does not exist");
        courier.Person.FirstName = fname;
        courier.Person.LastName = lname;
        courier.Person.Number = num;
        await _context.SaveChangesAsync();
    }
}