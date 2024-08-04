using System.ComponentModel.DataAnnotations;

namespace emprestimo_livro.Models {

    public class Livro {

        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Autor { get; set; }

        public required string Editora { get; set; }

        public required string AnoPublicacao { get; set; }

        public virtual ICollection<LivroClienteEmprestimo>? LivroClienteEmprestimo { get; set; }
    }
}