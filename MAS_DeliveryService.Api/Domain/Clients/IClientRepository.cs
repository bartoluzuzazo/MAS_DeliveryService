namespace MAS_DeliveryService.Api.Domain.Clients;

public interface IClientRepository
{
    public Task AddClient(string fname, string lname, string num, string email);
}