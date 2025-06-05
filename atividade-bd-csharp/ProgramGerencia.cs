using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_bd_csharp
{
    public class ProgramGerencia
    {

        static async Task GerenciaRead()
        {
            IGerenciaRepository repo = new GerenciaRepository();
            var list = await repo.GetAllGerencia();

            foreach (var g in list)
            {
                Console.WriteLine($"Id: {g.Id}, Ativo: {g.Ativo}, Data Início: {g.DataInicio}, Data Fim: {g.DataFim}");
                Console.WriteLine($"Pessoa_Id: {g.Pessoa_Id}, Hotel_Id: {g.Hotel_Id}");
                Console.WriteLine("--------------------------------------");
            }
        }

        static async Task GerenciaCreate()
        {
            GerenciaInsertDTO g = new GerenciaInsertDTO();

            Console.Write("Está ativo? (true/false): ");
            g.Ativo = bool.Parse(Console.ReadLine());

            Console.Write("Data de início (yyyy-MM-dd): ");
            g.DataInicio = DateTime.Parse(Console.ReadLine());

            Console.Write("Data de fim (yyyy-MM-dd): ");
            g.DataFim = DateTime.Parse(Console.ReadLine());

            Console.Write("Pessoa_Id: ");
            g.Pessoa_Id = int.Parse(Console.ReadLine());

            Console.Write("Hotel_Id: ");
            g.Hotel_Id = int.Parse(Console.ReadLine());

            IGerenciaRepository repo = new GerenciaRepository();
            await repo.InsertGerencia(g);

            Console.WriteLine("Gerência cadastrada com sucesso.");
        }

    }
}
