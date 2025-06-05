using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.Repository;

namespace MyFirstCRUD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            char op;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GERENCIAMENTO ===");
                Console.WriteLine("1 - Gerenciar Especialidades");
                Console.WriteLine("2 - Gerenciar Lembretes");
                Console.WriteLine("3 - Gerenciar Pessoas");
                Console.WriteLine("4 - Gerenciar Gerência");
                Console.WriteLine("S - Sair");
                Console.Write("Escolha uma opção: ");
                string input = Console.ReadLine();
                op = input.Length > 0 ? char.ToUpper(input[0]) : '0';

                switch (op)
                {
                    case '1': await EspecialidadeMenu(); break;
                    case '2': await LembreteMenu(); break;
                    case '3': await PessoaMenu(); break;
                    case '4': await GerenciaMenu(); break;
                }
            } while (op != 'S');
        }

        static async Task EspecialidadeMenu()
        {
            IEspecialidadeRepository repo = new EspecialidadeRepository();
            await EntityMenu(
                "Especialidade",
                async () =>
                {
                    Console.Write("Nome: ");
                    return new EspecialidadeInsertDTO { Nome = Console.ReadLine() };
                },
                async () =>
                {
                    var list = await repo.GetAll();
                    foreach (var e in list)
                        Console.WriteLine($"Id: {e.Id}, Nome: {e.Nome}");
                },
                repo.Insert,
                repo.GetById,
                repo.Update,
                repo.Delete);
        }

        static async Task LembreteMenu()
        {
            ILembreteRepository repo = new LembreteRepository();
            await EntityMenu(
                "Lembrete",
                async () =>
                {
                    LembreteInsertDTO dto = new LembreteInsertDTO();
                    Console.Write("Título: "); dto.Titulo = Console.ReadLine();
                    Console.Write("Descrição: "); dto.Descricao = Console.ReadLine();
                    Console.Write("Data Início (yyyy-MM-dd): "); dto.DataInicio = DateTime.Parse(Console.ReadLine());
                    Console.Write("Data Fim (yyyy-MM-dd): "); dto.DataFim = DateTime.Parse(Console.ReadLine());
                    Console.Write("Frequência (0-Nenhum,1-Diario,2-Semanal,3-Mensal): ");
                    dto.Frequencia = (Frequencia)int.Parse(Console.ReadLine());
                    Console.Write("Pessoa_Id: "); dto.Pessoa_Id = int.Parse(Console.ReadLine());
                    return dto;
                },
                async () =>
                {
                    var list = await repo.GetAllLembrete();
                    foreach (var l in list)
                        Console.WriteLine($"Id: {l.Id}, Título: {l.Titulo}, Frequência: {l.Frequencia}");
                },
                repo.InsertLembrete,
                repo.GetLembreteById,
                repo.UpdateLembrete,
                repo.DeleteLembrete);
        }

        static async Task PessoaMenu()
        {
            IPessoaRepository repo = new PessoaRepository();
            await EntityMenu(
                "Pessoa",
                async () =>
                {
                    PessoaInsertDTO dto = new PessoaInsertDTO();
                    Console.Write("Nome: "); dto.Nome = Console.ReadLine();
                    Console.Write("Data Nascimento (yyyy-MM-dd): "); dto.DataNascimento = DateTime.Parse(Console.ReadLine());
                    Console.Write("CPF: "); dto.CPF = Console.ReadLine();
                    Console.Write("Telefone: "); dto.Telefone = Console.ReadLine();
                    Console.Write("Email: "); dto.Email = Console.ReadLine();
                    Console.Write("Senha: "); dto.Senha = Console.ReadLine();
                    Console.Write("Endereco da Foto: "); dto.EnderecoFoto = Console.ReadLine();
                    Console.Write("Possui Cão Guia (true/false): "); dto.CaoGuia = bool.Parse(Console.ReadLine());
                    Console.Write("CEP: "); dto.CEP = Console.ReadLine();
                    Console.Write("Bairro: "); dto.Bairro = Console.ReadLine();
                    Console.Write("Rua: "); dto.Rua = Console.ReadLine();
                    Console.Write("Número: "); dto.NumeroEndereco = Console.ReadLine();
                    Console.Write("Cidade_Id: "); dto.Cidade_Id = int.Parse(Console.ReadLine());
                    return dto;
                },
                async () =>
                {
                    var list = await repo.GetAllPessoa();
                    foreach (var p in list)
                        Console.WriteLine($"Id: {p.Id}, Nome: {p.Nome}, Email: {p.Email}");
                },
                repo.InsertPessoa,
                repo.GetPessoaById,
                repo.UpdatePessoa,
                repo.DeletePessoa);
        }

        static async Task GerenciaMenu()
        {
            IGerenciaRepository repo = new GerenciaRepository();
            await EntityMenu(
                "Gerência",
                async () =>
                {
                    GerenciaInsertDTO dto = new GerenciaInsertDTO();
                    Console.Write("Ativo (true/false): "); dto.Ativo = bool.Parse(Console.ReadLine());
                    Console.Write("Data Início (yyyy-MM-dd): "); dto.DataInicio = DateTime.Parse(Console.ReadLine());
                    Console.Write("Data Fim (yyyy-MM-dd): "); dto.DataFim = DateTime.Parse(Console.ReadLine());
                    Console.Write("Pessoa_Id: "); dto.Pessoa_Id = int.Parse(Console.ReadLine());
                    Console.Write("Hotel_Id: "); dto.Hotel_Id = int.Parse(Console.ReadLine());
                    return dto;
                },
                async () =>
                {
                    var list = await repo.GetAllGerencia();
                    foreach (var g in list)
                        Console.WriteLine($"Id: {g.Id}, Ativo: {g.Ativo}, Pessoa_Id: {g.Pessoa_Id}, Hotel_Id: {g.Hotel_Id}");
                },
                repo.InsertGerencia,
                repo.GetGerenciaById,
                repo.UpdateGerencia,
                repo.DeleteGerencia);
        }

        // Menu CRUD genérico
        static async Task EntityMenu<TInsert, TEntity>(
            string nomeEntidade,
            Func<Task<TInsert>> CreateInput,
            Func<Task> PrintAll,
            Func<TInsert, Task> Insert,
            Func<int, Task<TEntity>> GetById,
            Func<TEntity, Task> Update,
            Func<int, Task> Delete)
            where TEntity : class
        {
            char op;
            do
            {
                Console.Clear();
                Console.WriteLine($"-- {nomeEntidade.ToUpper()} --");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
                Console.WriteLine("V - Voltar");

                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case 'C':
                        var dto = await CreateInput();
                        await Insert(dto);
                        Console.WriteLine($"{nomeEntidade} criado com sucesso!");
                        break;
                    case 'R':
                        await PrintAll();
                        break;
                    case 'U':
                        await PrintAll();
                        Console.Write("Digite o ID a atualizar: ");
                        int id = int.Parse(Console.ReadLine());
                        dynamic entity = await GetById(id);
                        Console.WriteLine("Atualize os campos manualmente no código (exemplo simplificado).");
                        await Update(entity);
                        Console.WriteLine($"{nomeEntidade} atualizado com sucesso!");
                        break;
                    case 'D':
                        await PrintAll();
                        Console.Write("Digite o ID a excluir: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        await Delete(deleteId);
                        Console.WriteLine($"{nomeEntidade} excluído com sucesso!");
                        break;
                }

                if (op != 'V') { Console.WriteLine("Pressione Enter para continuar."); Console.ReadLine(); }

            } while (op != 'V');
        }
    }
}
