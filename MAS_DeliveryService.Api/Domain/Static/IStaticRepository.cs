namespace MAS_DeliveryService.Api.Domain.Static;

public interface IStaticRepository
{
    public Task SetStatic(Static @static);

    public Task<decimal> GetMaxWeight();
    
    public Task<int> GetYearlyVacationDays();
}