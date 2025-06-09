using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.atividade_bd_csharp.Entity
{
    public class OrdemServicoEntity
    {
        public int Id { get; set; }
        public string DataCriacao { get; set; }
        public string StatusOs { get; set; }
        public int Pessoa_Id { get; set; }
    }
}