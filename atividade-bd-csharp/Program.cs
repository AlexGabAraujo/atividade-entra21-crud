using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.Entity;
using atividade_bd_csharp.Repository;
using Dapper;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Repository;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace MyFirstCRUD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            char op = '0';

            do
            {
                Console.WriteLine("""
                ----------------- MENU ------------------
                --TABELAS: 
                1 - Especialidade
                2 - Aviao
                0 - Sair

                Escolha qual tabela você deseja editar: 
                """);

                op = Console.ReadLine().ToUpper()[0];

                Console.Clear();

                switch (op)
                {
                    case '1':
                        await CRUDEspecialidade();
                        break;
                    case '2':
                        await Read();
                        break;
                    case '0':
                        Console.WriteLine("Finalizando...");
                        break;
                }

            } while (op != '0');
        }

        static async Task CRUDEspecialidade()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Especialidade --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);
                

                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await EspecialidadeCreate();
                        break;
                    case '2':
                        await EspecialidadeRead();
                        break;
                    case '3':
                        await EspecialidadeUpdate();
                        break;
                    case '4':
                        await EspecialidadeDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task EspecialidadeRead()
        {
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            IEnumerable<EspecialidadeEntity> especialidadeList = await especialidadeRepository.GetAll();
            foreach (EspecialidadeEntity especialidade in especialidadeList)
            {
                Console.WriteLine($"Id: {especialidade.Id}");
                Console.WriteLine($"Nome: {especialidade.Nome}\n");
            }

        }

        static async Task EspecialidadeCreate()
        {
            EspecialidadeInsertDTO especialidade = new EspecialidadeInsertDTO();

            Console.WriteLine("Digite o nome da Especialidade: ");
            especialidade.Nome = Console.ReadLine();

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Insert(especialidade);
            Console.WriteLine("Especialidade cadastrada com sucesso.");
        }

        static async Task EspecialidadeDelete()
        {
            await EspecialidadeRead();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Delete(id);

            Console.WriteLine("Especialidade deletada com sucesso.");
        }

        static async Task EspecialidadeUpdate()
        {
            await EspecialidadeRead();
            Console.WriteLine("Digite o Id que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());
            
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            EspecialidadeEntity especialidade = await especialidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {especialidade.Nome} ou aperte 'Enter' para manter: ");

            string newName = Console.ReadLine();
            if(newName != string.Empty)
            {
                especialidade.Nome = newName;
                await especialidadeRepository.Update(especialidade);
                Console.WriteLine("Nome alterado com sucesso.");
            }
        }

        /* -----------------------------     TABELA AVIAO ------------------------------ */

        static async Task CRUDAviao()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Avião --------
                    1 - Create
                    2 - Read
                    3 - Update
                    4 - Delete
                    0 - Sair
                    
                    Escolha uma opção:
                    """);


                op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case '1':
                        await AviaoCreate();
                        break;
                    case '2':
                        await AviaoRead();
                        break;
                    case '3':
                        await AviaoUpdate();
                        break;
                    case '4':
                        await AviaoDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task AviaoRead()
        {
            IAviaoRepository aviaoRepository = new AviaoRepository();
            IEnumerable<AviaoEntity> aviaoList = await aviaoRepository.GetAll();
            foreach (var aviao in aviaoList)
            {
                Console.WriteLine($"Id: {aviao.Id}");
                Console.WriteLine($"Nome: {aviao.Nome}\n");
            }

        }

        static async Task EspecialidadeCreate()
        {
            EspecialidadeInsertDTO especialidade = new EspecialidadeInsertDTO();

            Console.WriteLine("Digite o nome da Especialidade: ");
            especialidade.Nome = Console.ReadLine();

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Insert(especialidade);
            Console.WriteLine("Especialidade cadastrada com sucesso.");
        }

        static async Task EspecialidadeDelete()
        {
            await EspecialidadeRead();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Delete(id);

            Console.WriteLine("Especialidade deletada com sucesso.");
        }

        static async Task EspecialidadeUpdate()
        {
            await EspecialidadeRead();
            Console.WriteLine("Digite o Id que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            EspecialidadeEntity especialidade = await especialidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {especialidade.Nome} ou aperte 'Enter' para manter: ");

            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                especialidade.Nome = newName;
                await especialidadeRepository.Update(especialidade);
                Console.WriteLine("Nome alterado com sucesso.");
            }
        }
    }
}