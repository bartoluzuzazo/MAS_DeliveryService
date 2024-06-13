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
}