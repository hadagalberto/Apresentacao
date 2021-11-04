using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Net.Domain.Entity
{
    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }
        public string UsuarioCriacao { get; set; }
        public DateTime HoraCriacao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime HoraAtualizacao { get; set; }


    }
}
