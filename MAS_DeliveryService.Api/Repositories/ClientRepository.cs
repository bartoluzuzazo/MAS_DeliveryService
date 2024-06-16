using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.People;

namespace MAS_DeliveryService.Api.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly Context _context;

    public ClientRepository(Context context)
    {
        _context = context;
    }
    
    public async Task AddClient(string fname, string lname, string num, string email)
    {
        var person = new Person(fname, lname, num);
        await _context.Persons.AddAsync(person);
        var client = new Client(email, person.Id);
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task AddClient(Guid personId, string email)
    {
        var client = new Client(email, personId);
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }
}