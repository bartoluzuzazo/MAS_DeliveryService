﻿using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Items;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly Context _context;

    public ItemRepository(Context context)
    {
        _context = context;
    }

    public async Task AddItem(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Item>> GetItems()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> GetItem(Guid id)
    {
        return await _context.Items.FirstAsync(i => i.Id == id);
    }

    public async Task<bool> ItemExists(Guid id)
    {
        return await _context.Orders.AnyAsync(o => o.Id == id);
    }
}