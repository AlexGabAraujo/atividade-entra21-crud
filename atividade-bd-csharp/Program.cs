using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.DTO;
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
                3 - Assento
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
                        await CRUDAviao();
                        break;
                    case '3':
                        await CRUDAssento();
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

        /* ----------------------------- TABELA AVIAO ------------------------------ */

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
                Console.WriteLine($"Quantidade de Vagas: {aviao.QuantidadeVaga}");
                Console.WriteLine($"Código de Registro: {aviao.CodigoRegistro}");
                Console.WriteLine($"Companhia: {aviao.Companhia}");
                Console.WriteLine($"Modelo: {aviao.Modelo}");
                Console.WriteLine($"Fabricante: {aviao.Fabricante}\n");

            }

        }

        static async Task AviaoCreate()
        {
            AviaoInsertDTO aviao = new AviaoInsertDTO();

            Console.WriteLine("Digite a quantidade de vagas: ");
            aviao.QuantidadeVaga = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o código de registro: ");
            aviao.CodigoRegistro = Console.ReadLine();

            Console.WriteLine("Digite a companhia: ");
            aviao.Companhia = Console.ReadLine();

            Console.WriteLine("Digite o modelo: ");
            aviao.Modelo = Console.ReadLine();

            Console.WriteLine("Digite o fabricante: ");
            aviao.Fabricante = Console.ReadLine();

            IAviaoRepository aviaoRepository = new AviaoRepository();
            await aviaoRepository.Insert(aviao);

            Console.WriteLine("Avião cadastrado com sucesso.");
        }

        static async Task AviaoDelete()
        {
            await AviaoRead();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IAviaoRepository aviaoRepository = new AviaoRepository();
            await aviaoRepository.Delete(id);

            Console.WriteLine("Avião deletado com sucesso.");
        }

        static async Task AviaoUpdate()
        {
            await AviaoRead();

            Console.WriteLine("Digite o Id do avião que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IAviaoRepository aviaoRepository = new AviaoRepository();
            AviaoEntity aviao = await aviaoRepository.GetById(id);

            Console.WriteLine($"Digite nova quantidade de vagas ({aviao.QuantidadeVaga}) ou aperte 'Enter' para manter:");
            string input = Console.ReadLine();
            if (input != string.Empty)
                aviao.QuantidadeVaga = int.Parse(input);

            Console.WriteLine($"Digite novo código de registro ({aviao.CodigoRegistro}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.CodigoRegistro = input;

            Console.WriteLine($"Digite nova companhia ({aviao.Companhia}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.Companhia = input;

            Console.WriteLine($"Digite novo modelo ({aviao.Modelo}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.Modelo = input;

            Console.WriteLine($"Digite novo fabricante ({aviao.Fabricante}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                aviao.Fabricante = input;

            await aviaoRepository.Update(aviao);
            Console.WriteLine("Avião atualizado com sucesso.");
        }

        /* ----------------------------- TABELA ASSENTO ------------------------------ */

        static async Task CRUDAssento()
        {
            char op = '0';

            do
            {
                Console.WriteLine($"""
                    -------- Cadastro de Assento --------
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
                        await AssentoCreate();
                        break;
                    case '2':
                        await AssentoRead();
                        break;
                    case '3':
                        await AssentoUpdate();
                        break;
                    case '4':
                        await AssentoDelete();
                        break;
                    case '0':
                        break;
                }

                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != '0');
        }

        static async Task AssentoRead()
        {
            IAssentoRepository assentoRepository = new AssentoRepository();
            IEnumerable<AssentoEntity> assentoList = await assentoRepository.GetAll();

            foreach (var assento in assentoList)
            {
                Console.WriteLine($"Id: {assento.Id}");
                Console.WriteLine($"Número: {assento.Numero}");
                Console.WriteLine($"Tipo: {assento.Tipo}");
                Console.WriteLine($"Avião Id: {assento.Aviao_Id}\n");
            }
        }

        static async Task AssentoCreate()
        {
            AssentoInsertDTO assento = new AssentoInsertDTO();

            Console.WriteLine("Digite o número do assento: ");
            assento.Numero = Console.ReadLine();

            Console.WriteLine("Digite o número do tipo do assento (1 - ECONOMICO, 2 - EXECUTIVO, 3 - PRIMEIRA CLASSE): ");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                assento.Tipo = "Economico";
            }
            else if (opc == 2)
            {
                assento.Tipo = "Executivo";
            }
            else if (opc == 3)
            {
                assento.Tipo = "Primeira Classe";
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                return;
            }

            Console.WriteLine("Digite o ID do avião vinculado: ");
            assento.Aviao_Id = int.Parse(Console.ReadLine());

            IAssentoRepository assentoRepository = new AssentoRepository();
            await assentoRepository.Insert(assento);

            Console.WriteLine("Assento cadastrado com sucesso.");
        }

        static async Task AssentoDelete()
        {
            await AssentoRead();

            Console.WriteLine("Digite o Id do assento que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IAssentoRepository assentoRepository = new AssentoRepository();
            await assentoRepository.Delete(id);

            Console.WriteLine("Assento deletado com sucesso.");
        }

        static async Task AssentoUpdate()
        {
            await AssentoRead();

            Console.WriteLine("Digite o Id do assento que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IAssentoRepository assentoRepository = new AssentoRepository();
            AssentoEntity assento = await assentoRepository.GetById(id);

            Console.WriteLine($"Digite novo número ({assento.Numero}) ou aperte 'Enter' para manter:");
            string input = Console.ReadLine();
            if (input != string.Empty)
                assento.Numero = input;

            Console.WriteLine($"Digite novo tipo ({assento.Tipo}) ou aperte 'Enter' para manter: (1 - ECONOMICO, 2 - EXECUTIVO, 3 - PRIMEIRA CLASSE): ");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                assento.Tipo = "Economico";
            }
            else if (opc == 2)
            {
                assento.Tipo = "Executivo";
            }
            else if (opc == 3)
            {
                assento.Tipo = "Primeira Classe";
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                return;
            }

            Console.WriteLine($"Digite novo Avião Id ({assento.Aviao_Id}) ou aperte 'Enter' para manter:");
            input = Console.ReadLine();
            if (input != string.Empty)
                assento.Aviao_Id = int.Parse(input);

            await assentoRepository.Update(assento);
            Console.WriteLine("Assento atualizado com sucesso.");
        }

    }
}