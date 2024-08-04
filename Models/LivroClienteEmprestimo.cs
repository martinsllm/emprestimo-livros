using System.ComponentModel.DataAnnotations;

namespace emprestimo_livro.Models {

    public class LivroClienteEmprestimo {

        [Key]
        public int Id { get; set; }

        public virtual required Cliente Cliente { get; set; }

        public virtual required Livro Livro { get; set; }

        public required DateTime DataEmprestimo { get; set; }

        public required DateTime DataDevolucao { get; set; }

        public required bool Entregue { get; set; }
    }
}