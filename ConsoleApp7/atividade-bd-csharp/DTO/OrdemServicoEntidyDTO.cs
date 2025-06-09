using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.atividade_bd_csharp.DTO
{
    public class OrdemServicoEntityDTO
    {
        public DateTime DataCriacao { get; set; }
        public string StatusOs { get; set; }
        public int PessoaId { get; set; }
    }
}
