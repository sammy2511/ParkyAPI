using Microsoft.EntityFrameworkCore;
using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Data
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ApplicationDBContext : DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options) : base(options)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public DbSet<NationalPark> NationalParks { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
