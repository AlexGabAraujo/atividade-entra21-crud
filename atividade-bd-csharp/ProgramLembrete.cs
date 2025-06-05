using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.Repository;

namespace MyFirstCRUD
{
    internal class ProgramLembrete
    {
        static async Task Main(string[] args)
        {
            char op = '0';

            do
            {
                Console.WriteLine("-- Cadastro de Lembretes --");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
                Console.WriteLine("S - SAIR");

                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case 'C':
                        await Create();
                        break;
                    case 'R':
                        await Read();
                        break;
                    case 'U':
                        await Update();
                        break;
                    case 'D':
                        await Delete();
                        break;
                }

                Console.WriteLine("\nPressione Enter para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != 'S');
        }

        static async Task Read()
        {
            ILembreteRepository lembreteRepository = new LembreteRepository();
            var lembretes = await lembreteRepository.GetAllLembrete();

            foreach (var l in lembretes)
            {
                Console.WriteLine($"Id: {l.Id}");
                Console.WriteLine($"Título: {l.Titulo}");
                Console.WriteLine($"Descrição: {l.Descricao}");
                Console.WriteLine($"Data Início: {l.DataInicio}");
                Console.WriteLine($"Data Fim: {l.DataFim}");
                Console.WriteLine($"Frequência: {l.Frequencia}");
                Console.WriteLine($"Pessoa ID: {l.Pessoa_Id}");
                Console.WriteLine("-----------------------------\n");
            }
        }

        static async Task Create()
        {
            LembreteInsertDTO lembrete = new LembreteInsertDTO();

            Console.Write("Digite o título: ");
            lembrete.Titulo = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            lembrete.Descricao = Console.ReadLine();

            Console.Write("Digite a data de início (yyyy-MM-dd): ");
            lembrete.DataInicio = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a data de fim (yyyy-MM-dd): ");
            lembrete.DataFim = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a frequência (0 - Nenhum, 1 - Diario, 2 - Semanal, 3 - Mensal): ");
            lembrete.Frequencia = (Frequencia)int.Parse(Console.ReadLine());

            Console.Write("Digite o ID da pessoa: ");
            lembrete.Pessoa_Id = int.Parse(Console.ReadLine());

            ILembreteRepository lembreteRepository = new LembreteRepository();
            await lembreteRepository.InsertLembrete(lembrete);

            Console.WriteLine("Lembrete cadastrado com sucesso!");
        }

        static async Task Delete()
        {
            await Read();
            Console.Write("Digite o ID do lembrete a ser deletado: ");
            int id = int.Parse(Console.ReadLine());

            ILembreteRepository lembreteRepository = new LembreteRepository();
            await lembreteRepository.DeleteLembrete(id);

            Console.WriteLine("Lembrete deletado com sucesso.");
        }

        static async Task Update()
        {
            await Read();
            Console.Write("Digite o ID do lembrete que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            ILembreteRepository lembreteRepository = new LembreteRepository();
            var lembrete = await lembreteRepository.GetLembreteById(id);

            Console.Write($"Título atual ({lembrete.Titulo}): ");
            string titulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(titulo)) lembrete.Titulo = titulo;

            Console.Write($"Descrição atual ({lembrete.Descricao}): ");
            string descricao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(descricao)) lembrete.Descricao = descricao;

            Console.Write($"Data Início atual ({lembrete.DataInicio:yyyy-MM-dd}): ");
            string dataInicio = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dataInicio)) lembrete.DataInicio = DateTime.Parse(dataInicio);

            Console.Write($"Data Fim atual ({lembrete.DataFim:yyyy-MM-dd}): ");
            string dataFim = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dataFim)) lembrete.DataFim = DateTime.Parse(dataFim);

            Console.Write($"Frequência atual ({lembrete.Frequencia}): ");
            string freq = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(freq)) lembrete.Frequencia = (Frequencia)int.Parse(freq);

            Console.Write($"Pessoa_Id atual ({lembrete.Pessoa_Id}): ");
            string pessoa = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(pessoa)) lembrete.Pessoa_Id = int.Parse(pessoa);

            await lembreteRepository.UpdateLembrete(lembrete);
            Console.WriteLine("Lembrete atualizado com sucesso.");
        }
    }
}
