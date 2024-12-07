using KTHDV_BTH5.Models;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTHDV_BTH5.Data
{
    public class ReportingContext : DbContext 
    { 
        public ReportingContext(DbContextOptions<ReportingContext> options) 
            : base(options) { } 
        public DbSet<KTHDV_BTH5.Models.OrderReport> OrderReports { get; set; } = default!;
        public DbSet<KTHDV_BTH5.Models.ProductReport> ProductReports { get; set; } = default!;
    }
}



