using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DbContextApi: DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbContextApi(DbContextOptions<DbContextApi> options) : base(options)
        {

        }
    }
}
