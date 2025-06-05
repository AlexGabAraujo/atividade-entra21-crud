using MyFirstCRUD.Entity;
using System;

namespace MyFirstCRUD.DTO
{
    public class LembreteInsertDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Frequencia Frequencia { get; set; }
        public int Pessoa_Id { get; set; }
    }
}
