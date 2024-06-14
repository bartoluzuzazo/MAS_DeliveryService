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
        var person = new Person()
        {
            FirstName = fname,
            LastName = lname,
            Number = num,
        };
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        var client = new Client()
        {
            Email = email,
            PersonId = person.Id
        };
        
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

    }
}