using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.Managers;
using MAS_DeliveryService.Api.Domain.People;

namespace MAS_DeliveryService.Api.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly Context _context;

    public ManagerRepository(Context context)
    {
        _context = context;
    }

    public async Task AddManager(string fname, string lname, string num, DateTime dateOfBirth, decimal salary, ContractType contractType,
        string education)
    {
        var person = new Person(fname, lname, num);
        await _context.Persons.AddAsync(person);
        var manager = new Manager(person.Id, dateOfBirth, salary, contractType, education);
        await _context.Managers.AddAsync(manager);
        await _context.SaveChangesAsync();
    }

    public async Task AddManager(Guid personId, DateTime dateOfBirth, decimal salary, ContractType contractType, string education)
    {
        var manager = new Manager(personId, dateOfBirth, salary, contractType, education);
        await _context.Managers.AddAsync(manager);
        await _context.SaveChangesAsync();
    }
}