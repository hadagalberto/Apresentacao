using System;
using System.ComponentModel.DataAnnotations;

namespace PDV.Net.Domain.DTO
{
    public class ProdutoDTO : BaseDTO
    {

        [Display(Name = "Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }
        public string ValorHelper { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Valor { get; set; }
        public string CustoHelper { get; set; }
        public double Custo { get; set; }
        [Display(Name = "Descrição")]
        [MaxLength(250)]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        [Display(Name = "Categoria")]
        public Guid? IdCategoriaProduto { get; set; }

    }
}
