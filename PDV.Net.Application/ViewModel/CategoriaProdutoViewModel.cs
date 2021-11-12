using System.ComponentModel.DataAnnotations;

namespace PDV.Net.Application.ViewModel
{
    public class CategoriaProdutoViewModel : BaseViewModel
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50)]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

    }
}
