﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.PackageItems;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Domain.Packages;

[Table(nameof(Package)), Index(nameof(SerialNumber), IsUnique = true)]
public class Package
{
    private Guid? _deliveredInId;

    public Package(string serialNumber, string? comment, Guid sentInId)
    {
        Id = Guid.NewGuid();
        SerialNumber = serialNumber;
        Comment = comment;
        SentInId = sentInId;
        DeliveredInId = null;
    }

    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string SerialNumber { get; set; }

    [Length(1, 500)]
    public string? Comment { get; set; }

    public decimal Weight => PackageItems.Sum(pi => pi.Package.Weight);

    public Guid SentInId { get; set; }

    [ForeignKey(nameof(SentInId))]
    public virtual Order SentIn { get; set; }

    public Guid? DeliveredInId
    {
        get => _deliveredInId;
        set
        {
            if (value is not null && value != SentInId) throw new Exception("DeliveredIn must be the same value as SentIn");
            _deliveredInId = value;
        }
    }

    [ForeignKey(nameof(DeliveredInId))]
    public virtual Order? DeliveredIn { get; set; }

    public virtual ICollection<PackageItem> PackageItems { get; set; }
    
    public List<Item> GetItems()
    {
        return PackageItems.Select(pi => pi.Item).OrderBy(i => i.Weight).ToList();
    }
}