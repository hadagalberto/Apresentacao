using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Net.Domain.Entity
{
    public class CategoriaProduto : BaseEntity
    {

        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
