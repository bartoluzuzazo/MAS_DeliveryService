using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.People;

namespace MAS_DeliveryService.Api.Domain.Workers;

[Table(nameof(Worker))]
public abstract class Worker
{
    [Key] 
    public Guid Id { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public ContractType Discriminator { get; set; }
    
    public decimal? SalaryPerHour { get; set; }
    public decimal? MonthlySalary { get; set; }
    public int? VacationDaysLeft { get; set; }

    public Guid PersonId { get; set; }
    
    [ForeignKey(nameof(PersonId))]    
    public virtual Person Person { get; set; }

    public void MakeEmployee(decimal salary)
    {
        MonthlySalary = salary;
        VacationDaysLeft = 0;
        SalaryPerHour = null;
        Discriminator = ContractType.Employee;
    }
    public void MakeContractor(decimal salary)
    {
        MonthlySalary = null;
        VacationDaysLeft = null;
        SalaryPerHour = salary;
        Discriminator = ContractType.Contractor;
    }
}