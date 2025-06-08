using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_bd_csharp.Entity
{
    public class HotelEntity
    {
        public int Id { get; set; } 
        public string CNPJ{ get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string EnderecoFoto { get; set; }
        public string Site { get; set; }
        public string Acessibilidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string NumeroEndereco { get; set; }
        public string Cidade_Id { get; set; }
        
        public StatusTipo Tipo { get; set; }

        public enum StatusTipo
        {
            Hotel,
            Apartamento,
            Casa,
            Hostel,
            Pousada
        }


    }
}
