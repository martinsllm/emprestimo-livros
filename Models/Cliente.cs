using System.ComponentModel.DataAnnotations;

namespace emprestimo_livro.Models {

    public class Cliente {

        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string Telefone { get; set; }

        public ICollection<Emprestimo>? Emprestimo { get; set; }
    }
}