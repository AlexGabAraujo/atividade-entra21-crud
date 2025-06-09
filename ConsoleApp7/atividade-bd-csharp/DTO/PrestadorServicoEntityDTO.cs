using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.atividade_bd_csharp.DTO
{
    public class PrestadorServicoEntityDTO
    {
        public decimal PrecoHora { get; set; }
        public string Observacao { get; set; }
        public string CNPJ { get; set; }
        public int EspecialidadeId { get; set; }
        public int PessoaId { get; set; }
    }
}

