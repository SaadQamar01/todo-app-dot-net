using System;
using Microsoft.EntityFrameworkCore;

namespace payment_crud.Models
{
    public class PaymentDetailsContext : DbContext
    {
        public PaymentDetailsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}

