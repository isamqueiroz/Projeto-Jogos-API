using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jogos_API.Domains
{
    [Table("Usuario") ]
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }
        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "nome obrigatório!")]

        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "NickName obrigatório!")]
        public string? NickName { get; set; }

        public Guid? JogoId { get; set; }
        [ForeignKey("JogoId")]
        public Jogo? jogo { get; set; }

    }
}
