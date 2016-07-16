using DTO;
using System.Data.Entity.ModelConfiguration;

namespace Map
{
    public class GeneroMap : EntityTypeConfiguration<Genero>
    {
        public GeneroMap()
        {
            ToTable("Genero");

            HasKey(m => m.IdGenero);

            Property(m => m.NomeGenero).HasMaxLength(100).IsRequired();

        }
    }
}
