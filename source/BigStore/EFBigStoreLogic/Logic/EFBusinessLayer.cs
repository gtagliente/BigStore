﻿using BigStoreCore.Interfaces;
using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStore.Logic
{
    public class EFBusinessLayer : IMainBusinessLayer
    {
        public BigStoreContext _context;
        public EFBusinessLayer(BigStoreContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<MenuDiscount>> GetMenuDiscounts()
        {

            return await _context.MenuDiscounts.ToListAsync();
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            return await _context.Discounts.ToListAsync();
        }
    }
}
