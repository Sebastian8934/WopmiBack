﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<DeliveryInfo> DeliveryInfo { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<TransactionItem> TransactionItem { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
