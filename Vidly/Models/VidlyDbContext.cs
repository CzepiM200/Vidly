﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}