using System.Diagnostics;
using System.Threading.Tasks;
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

            static async Task Delet()
            {

            }
            static async Task Insert()
            {

            }


            ///do
            {

            ///} while ()

            ////
            
            char op = '0';

            do
            {
                Console.WriteLine("-- Cadastro de Especialidade --");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE\n");
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

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != 'S');
        }

        static async Task Read()
        {
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            IEnumerable<EspecialidadeEntity> especialidadeList = await especialidadeRepository.GetAll();
            foreach (EspecialidadeEntity especialidade in especialidadeList)
            {
                Console.WriteLine($"Id: {especialidade.Id}");
                Console.WriteLine($"Nome: {especialidade.Nome}\n");
            }

        }

        static async Task Create()
        {
            EspecialidadeInsertDTO especialidade = new EspecialidadeInsertDTO();

            Console.WriteLine("Digite o nome da Especialidade: ");
            especialidade.Nome = Console.ReadLine();

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Insert(especialidade);
            Console.WriteLine("Especialidade cadastrada com sucesso.");
        }

        static async Task Delete()
        {
            await Read();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Delete(id);

            Console.WriteLine("Especialidade deletada com sucesso.");
        }

        static async Task Update()
        {
            await Read();
            Console.WriteLine("Digite o Id que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());
            
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            EspecialidadeEntity especialidade = await especialidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {especialidade.Nome} ou aperte 'Enter' para manter: ");

            string newName = Console.ReadLine();
            if(newName != string.Empty)
            {
                especialidade.Nome = newName;
                Console.WriteLine("Nome alterado com sucesso.");
            }
        }
    }
}
    }