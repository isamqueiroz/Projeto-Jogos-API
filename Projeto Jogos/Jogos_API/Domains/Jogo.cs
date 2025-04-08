using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jogos_API.Domains
{
    [Table("Jogo")]
    [Index(nameof(NomeDoJogo), IsUnique = true)]
    public class Jogo
    {
     
        [Key]
        public Guid JogoId { get; set; }

        
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "o nome do jogo é obrigatório!")]
        public string? NomeDoJogo { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Plataforma { get; set; }
   
    }
}
