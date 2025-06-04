using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_bd_csharp.Entity
{
    public class CamaQuartoEntity
    {
        public int Id { get; set; }
        public int quantidade { get; set; }
        public string Enum { get; set; }
        public int QuartoIdEnum { get; set; }

    }
}
