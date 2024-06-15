using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.Workers;

namespace MAS_DeliveryService.Api.Domain.Managers;

[Table(nameof(Manager))]
public class Manager : Worker
{
    public Manager(Guid personId, DateTime dateOfBirth, decimal salary, ContractType contractType, string education)
    {
        PersonId = personId;
        DateOfBirth = dateOfBirth;
        Education = education;
        if (contractType == ContractType.Contractor) MakeContractor(salary);
        else MakeEmployee(salary);
    }

    [Required, Length(1, 500)]
    public string Education { get; set; }
}