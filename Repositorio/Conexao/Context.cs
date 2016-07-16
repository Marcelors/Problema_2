using DTO;
using Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repositorio.Conexao
{
    public class Context : DbContext
    {
        public Context() : base("strConexao")
        {
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Livro> Livro { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
            .Where(p => p.Name == "Id"+p.ReflectedType.Name)
            .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new GeneroMap());
            modelBuilder.Configurations.Add(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }



    }
}
