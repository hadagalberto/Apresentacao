using System;
using System.ComponentModel.DataAnnotations;

namespace PDV.Net.Application.ViewModel
{
    public class ProdutoViewModel : BaseViewModel
    {

        [Display(Name = "Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Valor { get; set; }
        public double Custo { get; set; }
        [Display(Name = "Descrição")]
        [MaxLength(250)]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        [Display(Name = "Categoria")]
        public Guid? IdCategoriaProduto { get; set; }

    }
}
