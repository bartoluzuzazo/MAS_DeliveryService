﻿using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Repositories;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly Context _context;

    public DeliveryRepository(Context context)
    {
        _context = context;
    }

    public async Task AddDelivery(Delivery delivery)
    {
        await _context.Deliveries.AddAsync(delivery);
        await _context.SaveChangesAsync();
    }

    public async Task<Delivery?> GetDelivery(Guid deliveryId)
    {
        return await _context.Deliveries.FirstOrDefaultAsync(d => d.Id == deliveryId);
    }
    
    public async Task<List<Delivery>> GetDeliveries()
    {
        return await _context.Deliveries.ToListAsync();
    }
}