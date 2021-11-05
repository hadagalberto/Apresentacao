using System.ComponentModel.DataAnnotations;

namespace PDV.Net.Domain.DTO
{
    public class CategoriaProdutoDTO : BaseDTO
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50)]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

    }
}
