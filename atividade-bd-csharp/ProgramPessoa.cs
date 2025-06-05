using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Repository;

public class ProgramPessoa
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Listar Pessoas");
        Console.WriteLine("2. Cadastrar Pessoa");
        Console.WriteLine("3. Sair");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await PessoaCreate();
                break;
            case "2":
                await PessoaRead();
                break;
            case "3":
                await PessoaUpdate();
                return;
                case"4":
                    await PessoaDelete  ();
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    static async Task PessoaRead()
    {
        IPessoaRepository repo = new PessoaRepository();
        var pessoas = await repo.GetAllPessoa();

        foreach (var p in pessoas)
        {
            Console.WriteLine($"Id: {p.Id}, Nome: {p.Nome}, CPF: {p.CPF}, Email: {p.Email}");
            Console.WriteLine("--------------------------------------");
        }
    }

    static async Task PessoaCreate()
    {
        PessoaInsertDTO pessoa = new PessoaInsertDTO();

        Console.Write("Nome: ");
        pessoa.Nome = Console.ReadLine();

        Console.Write("Data Nascimento (yyyy-MM-dd): ");
        pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());

        Console.Write("CPF: ");
        pessoa.CPF = Console.ReadLine();

        Console.Write("Telefone: ");
        pessoa.Telefone = Console.ReadLine();

        Console.Write("Email: ");
        pessoa.Email = Console.ReadLine();

        Console.Write("Senha: ");
        pessoa.Senha = Console.ReadLine();

        Console.Write("Foto (caminho): ");
        pessoa.EnderecoFoto = Console.ReadLine();

        Console.Write("Possui cão guia? (true/false): ");
        pessoa.CaoGuia = bool.Parse(Console.ReadLine());

        Console.Write("CEP: ");
        pessoa.CEP = Console.ReadLine();

        Console.Write("Bairro: ");
        pessoa.Bairro = Console.ReadLine();

        Console.Write("Rua: ");
        pessoa.Rua = Console.ReadLine();

        Console.Write("Número: ");
        pessoa.NumeroEndereco = Console.ReadLine();

        Console.Write("Cidade ID: ");
        pessoa.Cidade_Id = int.Parse(Console.ReadLine());

        IPessoaRepository repo = new PessoaRepository();
        await repo.InsertPessoa(pessoa);

        Console.WriteLine("Pessoa cadastrada com sucesso.");
    }

}