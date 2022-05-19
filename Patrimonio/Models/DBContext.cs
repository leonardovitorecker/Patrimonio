

using Microsoft.EntityFrameworkCore;

namespace Patrimonio.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> opcoes)
          : base(opcoes)
       { }

        public DbSet<DbUsuario> usuario { get; set; }

         public DbSet<DbDepartamento> departamento { get; set; }

         public DbSet<DbLocal> local { get; set; }

        public DbSet<DbCategoria> categoria { get; set; }

         public DbSet<DbFornecedor> fornecedor { get; set; }

          public DbSet<DbPatrimonio> patrimonio { get; set; }
    }
}
