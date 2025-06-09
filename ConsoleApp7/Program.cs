using ConsoleApp7.atividade_bd_csharp.Contracts.Repositori;
using ConsoleApp7.atividade_bd_csharp.DTO;
using ConsoleApp7.atividade_bd_csharp.Entity;
using ConsoleApp7.atividade_bd_csharp.Repository;

internal class Program
{
    static async Task Main(string[] args)
    {
        IPrestadorServico repo = new PrestadorServicoRepository();
        char op;

        do
        {
            Console.WriteLine("-- CRUD Prestador de Serviço --");
            Console.WriteLine("C - CREATE\nR - READ\nU - UPDATE\nD - DELETE\nS - SAIR");
            op = Console.ReadLine().ToUpper()[0];

            switch (op)
            {
                case 'C': await Create(repo); break;
                case 'R': await Read(repo); break;
                case 'U': await Update(repo); break;
                case 'D': await Delete(repo); break;
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        } while (op != 'S');
    }

    static async Task Create(IPrestadorServico repo)
    {
        var dto = new PrestadorServicoEntityDTO();

        Console.Write("Preço por Hora: ");
        dto.PrecoHora = decimal.Parse(Console.ReadLine());

        Console.Write("Observação: ");
        dto.Observacao = Console.ReadLine();

        Console.Write("CNPJ: ");
        dto.CNPJ = Console.ReadLine();

        Console.Write("Especialidade ID: ");
        dto.EspecialidadeId = int.Parse(Console.ReadLine());

        Console.Write("Pessoa ID: ");
        dto.PessoaId = int.Parse(Console.ReadLine());

        await repo.Insert(dto);
        Console.WriteLine("Prestador de serviço cadastrado com sucesso.");
    }

    static async Task Read(IPrestadorServico repo)
    {
        var list = await repo.GetAll();
        foreach (var p in list)
        {
            Console.WriteLine($"Id: {p.Id}, Preço: {p.PrecoHora}, CNPJ: {p.CNPJ}, Obs: {p.Observacao}, EspId: {p.EspecialidadeId}, PessoaId: {p.PessoaId}");
        }
    }

    static async Task Update(IPrestadorServico repo)
    {
        await Read(repo);
        Console.Write("Digite o ID do prestador a atualizar: ");
        int id = int.Parse(Console.ReadLine());

        var p = await repo.GetById(id);
        if (p == null)
        {
            Console.WriteLine("Prestador não encontrado.");
            return;
        }

        Console.Write($"Novo PreçoHora ({p.PrecoHora}): ");
        string preco = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(preco)) p.PrecoHora = decimal.Parse(preco);

        Console.Write($"Nova Observação ({p.Observacao}): ");
        string obs = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(obs)) p.Observacao = obs;

        Console.Write($"Novo CNPJ ({p.CNPJ}): ");
        string cnpj = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(cnpj)) p.CNPJ = cnpj;

        Console.Write($"Novo EspecialidadeId ({p.EspecialidadeId}): ");
        string espId = Console.ReadLine();
        if (int.TryParse(espId, out int newEspId)) p.EspecialidadeId = newEspId;

        Console.Write($"Novo PessoaId ({p.PessoaId}): ");
        string pesId = Console.ReadLine();
        if (int.TryParse(pesId, out int newPesId)) p.PessoaId = newPesId;

        await repo.Update(p);
        Console.WriteLine("Atualização realizada com sucesso.");
    }

    static async Task Delete(IPrestadorServico repo)
    {
        await Read(repo);
        Console.Write("Digite o ID a ser deletado: ");
        int id = int.Parse(Console.ReadLine());

        await repo.Delete(id);
        Console.WriteLine("Deletado com sucesso.");
    }
}
