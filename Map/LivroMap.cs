using DTO;
using System.Data.Entity.ModelConfiguration;

namespace Map
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");

            HasKey(m => m.IdLivro);

            Property(m => m.NomeLivro).HasMaxLength(100).IsRequired();
            Property(m => m.QtdExemplares).IsRequired();
            Property(m => m.DescricaoLivro).HasMaxLength(800);


            HasRequired(m => m.Genero)
              .WithMany()
              .HasForeignKey(m => m.IdGenero);


        }

    }
}
