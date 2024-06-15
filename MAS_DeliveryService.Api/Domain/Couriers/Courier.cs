using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Deliveries;
using MAS_DeliveryService.Api.Domain.DriversLicenses;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.Workers;

namespace MAS_DeliveryService.Api.Domain.Couriers;

[Table(nameof(Courier))]
public class Courier : Worker
{
    public Courier(Guid personId, DateTime dateOfBirth, decimal salary, ContractType contractType)
    {
        PersonId = personId;
        DateOfBirth = dateOfBirth;
        if (contractType == ContractType.Contractor)
        {
            Discriminator = ContractType.Contractor;
            SalaryPerHour = salary;
            MonthlySalary = null;
            VacationDaysLeft = null;
        }
        else
        {
            Discriminator = ContractType.Employee;
            SalaryPerHour = null;
            MonthlySalary = salary;
            VacationDaysLeft = 0;
        }
    }
    
    public Guid DriversLicenseId { get; set; }

    [ForeignKey(nameof(DriversLicenseId))]
    public DriversLicense DriversLicense { get; set; }
    
    public virtual ICollection<Delivery> Deliveries { get; set; }
}